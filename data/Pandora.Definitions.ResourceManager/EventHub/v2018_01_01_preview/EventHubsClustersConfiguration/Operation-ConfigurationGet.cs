using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersConfiguration
{
    internal class ConfigurationGetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ClusterId();

        public override Type? ResponseObject() => typeof(ClusterQuotaConfigurationPropertiesModel);

        public override string? UriSuffix() => "/quotaConfiguration/default";


    }
}
