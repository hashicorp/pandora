using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
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

        public override object? RequestObject()
        {
            return new ClusterQuotaConfigurationPropertiesModel();
        }

        public override ResourceID? ResourceId()
        {
            return new ClusterId();
        }

        public override object? ResponseObject()
        {
            return new ClusterQuotaConfigurationPropertiesModel();
        }

        public override string? UriSuffix()
        {
            return "/quotaConfiguration/default";
        }


    }
}
