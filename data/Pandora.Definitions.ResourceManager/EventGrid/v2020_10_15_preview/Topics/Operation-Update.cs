using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(TopicUpdateParametersModel);

        public override ResourceID? ResourceId() => new TopicId();

        public override Type? ResponseObject() => typeof(TopicModel);


    }
}
