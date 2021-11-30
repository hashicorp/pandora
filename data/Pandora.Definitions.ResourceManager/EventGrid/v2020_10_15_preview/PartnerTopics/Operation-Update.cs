using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerTopics
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override Type? RequestObject() => typeof(PartnerTopicUpdateParametersModel);

        public override ResourceID? ResourceId() => new PartnerTopicId();

        public override Type? ResponseObject() => typeof(PartnerTopicModel);


    }
}
