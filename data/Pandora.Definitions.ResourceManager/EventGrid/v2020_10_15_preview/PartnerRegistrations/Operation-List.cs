using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerRegistrations
{
    internal class ListOperation : Operations.GetOperation
    {
        public override Type? ResponseObject() => typeof(PartnerRegistrationsListResultModel);

        public override string? UriSuffix() => "/providers/Microsoft.EventGrid/partnerRegistrations";


    }
}
