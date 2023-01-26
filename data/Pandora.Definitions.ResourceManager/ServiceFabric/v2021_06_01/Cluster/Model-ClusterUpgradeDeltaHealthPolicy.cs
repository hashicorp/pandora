using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class ClusterUpgradeDeltaHealthPolicyModel
{
    [JsonPropertyName("applicationDeltaHealthPolicies")]
    public Dictionary<string, ApplicationDeltaHealthPolicyModel>? ApplicationDeltaHealthPolicies { get; set; }

    [JsonPropertyName("maxPercentDeltaUnhealthyApplications")]
    [Required]
    public int MaxPercentDeltaUnhealthyApplications { get; set; }

    [JsonPropertyName("maxPercentDeltaUnhealthyNodes")]
    [Required]
    public int MaxPercentDeltaUnhealthyNodes { get; set; }

    [JsonPropertyName("maxPercentUpgradeDomainDeltaUnhealthyNodes")]
    [Required]
    public int MaxPercentUpgradeDomainDeltaUnhealthyNodes { get; set; }
}
