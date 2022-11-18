using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClustersConfiguration;

internal class ConfigurationPatchOperation : Operations.PatchOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ClusterQuotaConfigurationPropertiesModel);

\t\tpublic override ResourceID? ResourceId() => new ClusterId();

\t\tpublic override Type? ResponseObject() => typeof(ClusterQuotaConfigurationPropertiesModel);

\t\tpublic override string? UriSuffix() => "/quotaConfiguration/default";


}
