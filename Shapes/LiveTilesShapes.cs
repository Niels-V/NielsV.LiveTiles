using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NielsV.LiveTiles.Services;
using Orchard;
using Orchard.DisplayManagement.Descriptors;

namespace NielsV.LiveTiles.Shapes
{
    public class LiveTilesShapes : IShapeTableProvider
    {
        private readonly IWorkContextAccessor _wca;
        private readonly ILiveTilesService _tilesService;

        public LiveTilesShapes(IWorkContextAccessor wca, ILiveTilesService tilesService)
        {
            _wca = wca;
            _tilesService = tilesService;
        }

        public void Discover(ShapeTableBuilder builder)
        {
            //nothing
        }
    }
}