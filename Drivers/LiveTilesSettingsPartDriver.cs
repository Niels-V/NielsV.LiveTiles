using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NielsV.LiveTiles.Models;
using NielsV.LiveTiles.Services;
using NielsV.LiveTiles.ViewModels;
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;

namespace NielsV.LiveTiles.Drivers
{
    public class LiveTilesSettingsPartDriver : ContentPartDriver<LiveTilesSettingsPart>
    {
        private readonly ISignals _signals;
        private readonly ILiveTilesService _tilesService;
        private readonly IOrchardServices _services;

        public LiveTilesSettingsPartDriver(ISignals signals, ILiveTilesService tilesService, IOrchardServices services)
        {
            _signals = signals;
            _tilesService = tilesService;
        }


        //protected override DriverResult Editor(LiveTilesSettingsPart part, dynamic shapeHelper) {
            
        //    return ContentShape("Parts_LiveTiles_LiveTilesSettings",
        //                       () => shapeHelper.EditorTemplate(
        //                           TemplateName: "Parts/LiveTiles.LiveTilesSettings",
        //                           Model: new LiveTilesSettingsViewModel {
        //                               TileColor = part.TileColor,
        //                               SmallTileUrl = part.SmallTileUrl
        //                           },
        //                           Prefix: Prefix)).OnGroup("LiveTiles");
        //}

        protected override DriverResult Editor(LiveTilesSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            _signals.Trigger("NielsV.LiveTiles.Changed");
            return Editor(part, shapeHelper);
        }

        
    }
}