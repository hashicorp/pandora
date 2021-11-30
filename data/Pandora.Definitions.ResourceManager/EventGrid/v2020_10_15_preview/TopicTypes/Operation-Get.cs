using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.TopicTypes
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new TopicTypeId();

        public override Type? ResponseObject() => typeof(TopicTypeInfoModel);


    }
}
