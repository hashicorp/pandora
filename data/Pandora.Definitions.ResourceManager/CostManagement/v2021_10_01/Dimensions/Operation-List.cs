using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Dimensions
{
    internal class ListOperation : Operations.GetOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

        public override ResourceID? ResourceId() => new ScopeId();

        public override Type? ResponseObject() => typeof(DimensionModel);

        public override Type? OptionsObject() => typeof(ListOperation.ListOptions);

        public override string? UriSuffix() => "/providers/Microsoft.CostManagement/dimensions";

        internal class ListOptions
        {
            [QueryStringName("$expand")]
            [Optional]
            public string Expand { get; set; }

            [QueryStringName("$filter")]
            [Optional]
            public string Filter { get; set; }

            [QueryStringName("$top")]
            [Optional]
            public int Top { get; set; }
        }
    }
}
