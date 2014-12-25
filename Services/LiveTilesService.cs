using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using NielsV.LiveTiles.Models;
using Orchard;
using Orchard.Caching;
using Orchard.MediaLibrary.Services;
using Orchard.Services;
using Orchard.ContentManagement;

namespace NielsV.LiveTiles.Services
{
    public interface ILiveTilesService : IDependency
    {
        string GetLiveTileUrl(LiveTileType format);

        XDocument GetBrowserConfig();
    }
    public class LiveTilesService : ILiveTilesService
    {
        private readonly IWorkContextAccessor _wca;
        private readonly ICacheManager _cacheManager;
        private readonly ISignals _signals;
        private readonly IClock _clock;
        private readonly IMediaLibraryService _mediaService;
        private readonly IOrchardServices _services;

        private const string TilesMediaFolder = "livetiles";

        public LiveTilesService(IWorkContextAccessor wca, ICacheManager cacheManager, ISignals signals, IClock clock, IMediaLibraryService mediaService, IOrchardServices services)
        {
            _wca = wca;
            _cacheManager = cacheManager;
            _signals = signals;
            _clock = clock;
            _mediaService = mediaService;
            _services = services;
        }

        public string GetLiveTileColor()
        {
            return _cacheManager.Get(
                "NielsV.LiveTiles.Tile.Color",
                ctx => {
                    ctx.Monitor(_signals.When("NielsV.LiveTiles.Changed"));
                    var liveTilesSettings = _services.WorkContext.CurrentSite.As<LiveTilesSettingsPart>();
                    return liveTilesSettings.TileColor;
                });
        }


        public string GetLiveTileUrl(LiveTileType format)
        {
            string cacheKey = string.Format("NielsV.LiveTiles.Tile.{0}", Enum.GetName(typeof(LiveTileType), format));
            return _cacheManager.Get(
                cacheKey,
                ctx => {
                    ctx.Monitor(_signals.When("NielsV.LiveTiles.Changed"));
                    var liveTilesSettings = _services.WorkContext.CurrentSite.As<LiveTilesSettingsPart>();
                    switch (format)
                    {
                        case LiveTileType.Small:
                            return liveTilesSettings.SmallTileUrl;
                        default:
                            return null;
                    }
                    
                });
        }

        public XDocument GetBrowserConfig()
        {
            return _cacheManager.Get("NielsV.LiveTiles.BrowserConfig", BuildBrowserConfig);
            
        }

        private XDocument BuildBrowserConfig(AcquireContext<string> ctx)
        { 
             ctx.Monitor(_clock.When(TimeSpan.FromHours(1.0))); 
             ctx.Monitor(_signals.When("NielsV.LiveTiles.Changed")); 

            var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));

             var browserconfigElement = new XElement("browserconfig");
             document.Add(browserconfigElement);
             var msapplicationElement = new XElement("msapplication");
             browserconfigElement.Add(msapplicationElement);

             var tileElement = new XElement("tile");
             msapplicationElement.Add(tileElement);

             foreach (LiveTileType format in Enum.GetValues(typeof(LiveTileType)))
             {
                 var elementName = GetElementName(format);
                 var source = GetLiveTileUrl(format);
                 if (!string.IsNullOrEmpty(source))
                 {
                     XElement iconElement = new XElement(elementName);
                     XAttribute sourceAttribute = new XAttribute("src", source);
                     iconElement.Add(sourceAttribute);
                     tileElement.Add(iconElement);
                 }
             }

             var liveTileColor = GetLiveTileColor();
             if (!string.IsNullOrEmpty(liveTileColor))
             {
                 tileElement.Add(new XElement("TileColor", liveTileColor));
             }

             return document; 
         }

        private string GetElementName(LiveTileType format)
        {
            int width = 0;
            int height = 0;
            string elementBase = "square";

            switch (format)
            {
                case LiveTileType.Small:
                    width = 70;
                    height = 70;
                    break;
                case LiveTileType.Medium:
                    width = 150;
                    height = 150;
                    break;
                case LiveTileType.Large:
                    width = 310;
                    height = 310;
                    break;
                case LiveTileType.Wide:
                    width = 310;
                    height = 150;
                    elementBase = "wide";
                    break;
                default:
                    break;
            }

            return string.Format("{0}{1}x{2}logo", elementBase, width, height);
        }


    }
}