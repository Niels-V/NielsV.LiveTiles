using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NielsV.LiveTiles.Services;

namespace NielsV.LiveTiles.Controllers
{
    public class BrowserConfigController : Controller
    {
        private readonly ILiveTilesService _tileService;

        public BrowserConfigController( 
             ILiveTilesService liveTilesService) { 
             _tileService = liveTilesService; 
         } 

        public ActionResult Xml()
        {
            return new XmlResult(_tileService.GetBrowserConfig());
        }

    }
}