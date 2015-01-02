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
        public string MediumTileUrl
        {
            get { return this.Retrieve(r => r.MediumTileUrl); }
            set { this.Store(r => r.MediumTileUrl, value); }
        }
        public string LargeTileUrl
        {
            get { return this.Retrieve(r => r.LargeTileUrl); }
            set { this.Store(r => r.LargeTileUrl, value); }
        }
        public string WideTileUrl
        {
            get { return this.Retrieve(r => r.WideTileUrl); }
            set { this.Store(r => r.WideTileUrl, value); }
        }
    }
}