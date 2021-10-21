using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    internal class VideoAnalyzersListBySubscriptionOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type? ResponseObject() => typeof(VideoAnalyzerCollectionModel);

        public override string? UriSuffix() => "/providers/Microsoft.Media/videoAnalyzers";


    }
}
