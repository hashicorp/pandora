using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new EventChannelId();

        public override Type? ResponseObject() => typeof(EventChannelModel);


    }
}
