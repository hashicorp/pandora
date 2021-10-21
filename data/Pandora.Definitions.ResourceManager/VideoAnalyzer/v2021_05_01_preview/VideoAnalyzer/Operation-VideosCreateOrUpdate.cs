using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    internal class VideosCreateOrUpdateOperation : Operations.PutOperation
    {
        public override Type? RequestObject() => typeof(VideoEntityModel);

        public override ResourceID? ResourceId() => new VideoId();

        public override Type? ResponseObject() => typeof(VideoEntityModel);


    }
}
