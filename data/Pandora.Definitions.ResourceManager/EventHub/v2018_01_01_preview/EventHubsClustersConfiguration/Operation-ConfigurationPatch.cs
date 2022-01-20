using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersConfiguration;

internal class ConfigurationPatchOperation : Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ClusterQuotaConfigurationPropertiesModel);

    public override ResourceID? ResourceId() => new ClusterId();

    public override Type? ResponseObject() => typeof(ClusterQuotaConfigurationPropertiesModel);

    public override string? UriSuffix() => "/quotaConfiguration/default";


}
