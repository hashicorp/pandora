using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    internal class ListEventTypesOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ResourceGroupProviderId();

        public override Type? ResponseObject() => typeof(EventTypesListResultModel);

        public override string? UriSuffix() => "/providers/Microsoft.EventGrid/eventTypes";


    }
}
