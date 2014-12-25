using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Annotations;
using NielsV.LiveTiles.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;

namespace NielsV.LiveTiles.Handlers
{
    [UsedImplicitly]
    public class LiveTilesSettingsPartHandler : ContentHandler
    {
        public LiveTilesSettingsPartHandler()
        {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<LiveTilesSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<LiveTilesSettingsPart>("LiveTilesSettings", "Parts/LiveTiles.LiveTilesSettings", "LiveTiles"));
       
        }

        public Localizer T { get; set; }

        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("LiveTiles")));
        }
    }
}