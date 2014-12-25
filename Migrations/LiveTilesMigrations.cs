using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data.Migration;
using Orchard.Data.Migration.Schema;

namespace NielsV.LiveTiles.Migrations
{
    public class LiveTilesMigrations : DataMigrationImpl
    {

        public int Create()
        {
            SchemaBuilder.CreateTable(
                "LiveTilesPartRecord",
                table => table
                             .ContentPartRecord()
                             .Column<string>("SmallTileUrl")
                             .Column<string>("TileColor")
                );
            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.DropTable("LiveTilesPartRecord");
            SchemaBuilder.CreateTable(
                "LiveTilesSettingsPartRecord",
                table => table
                             .ContentPartRecord()
                             .Column<string>("SmallTileUrl")
                             .Column<string>("TileColor")
                );
            return 2;
        }

    }
}