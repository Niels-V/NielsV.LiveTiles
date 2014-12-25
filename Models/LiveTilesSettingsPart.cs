using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace NielsV.LiveTiles.Models
{
    public class LiveTilesSettingsPart : ContentPart
    {
        public string TileColor {
            get { return this.Retrieve(r => r.TileColor); }
            set { this.Store(r => r.TileColor, value); }
        }

        public string SmallTileUrl
        {
            get { return this.Retrieve(r => r.SmallTileUrl); }
            set { this.Store(r => r.SmallTileUrl, value); }
        }
    }
}