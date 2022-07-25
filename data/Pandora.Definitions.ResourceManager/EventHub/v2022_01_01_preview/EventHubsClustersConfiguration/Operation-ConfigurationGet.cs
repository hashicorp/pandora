using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.EventHubsClustersConfiguration;

internal class ConfigurationGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ClusterId();

    public override Type? ResponseObject() => typeof(ClusterQuotaConfigurationPropertiesModel);

    public override string? UriSuffix() => "/quotaConfiguration/default";


}
