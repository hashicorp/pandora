using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.FleetMembers;


internal class FleetMemberPropertiesModel
{
    [JsonPropertyName("clusterResourceId")]
    [Required]
    public string ClusterResourceId { get; set; }

    [JsonPropertyName("group")]
    public string? Group { get; set; }

    [JsonPropertyName("provisioningState")]
    public FleetMemberProvisioningStateConstant? ProvisioningState { get; set; }
}
