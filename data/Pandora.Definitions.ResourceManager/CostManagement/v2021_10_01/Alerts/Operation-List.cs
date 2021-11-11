using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts
{
    internal class ListOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ScopeId();

        public override Type? ResponseObject() => typeof(AlertsResultModel);

        public override string? UriSuffix() => "/providers/Microsoft.CostManagement/alerts";


    }
}
