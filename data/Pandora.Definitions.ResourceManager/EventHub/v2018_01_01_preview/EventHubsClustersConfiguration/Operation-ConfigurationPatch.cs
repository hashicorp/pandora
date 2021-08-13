using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersConfiguration
{
    internal class ConfigurationPatchOperation : Operations.PatchOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(ClusterQuotaConfigurationPropertiesModel);
        }

        public override ResourceID? ResourceId()
        {
            return new ClusterId();
        }

        public override Type? ResponseObject()
        {
            return typeof(ClusterQuotaConfigurationPropertiesModel);
        }

        public override string? UriSuffix()
        {
            return "/quotaConfiguration/default";
        }


    }
}
