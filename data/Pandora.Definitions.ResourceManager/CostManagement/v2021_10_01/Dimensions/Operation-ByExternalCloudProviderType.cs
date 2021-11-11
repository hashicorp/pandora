using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Dimensions
{
    internal class ByExternalCloudProviderTypeOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ExternalCloudProviderTypeId();

        public override Type? ResponseObject() => typeof(DimensionModel);

        public override Type? OptionsObject() => typeof(ByExternalCloudProviderTypeOperation.ByExternalCloudProviderTypeOptions);

        public override string? UriSuffix() => "/dimensions";

        internal class ByExternalCloudProviderTypeOptions
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
