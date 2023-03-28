using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.ManagedClusters;


internal class AgentPoolNetworkProfileModel
{
    [JsonPropertyName("allowedHostPorts")]
    public List<PortRangeModel>? AllowedHostPorts { get; set; }

    [JsonPropertyName("applicationSecurityGroups")]
    public List<string>? ApplicationSecurityGroups { get; set; }

    [JsonPropertyName("nodePublicIPTags")]
    public List<IPTagModel>? NodePublicIPTags { get; set; }
}
