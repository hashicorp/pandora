using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Roles;


internal class KubernetesRolePropertiesModel
{
    [JsonPropertyName("hostPlatform")]
    [Required]
    public PlatformTypeConstant HostPlatform { get; set; }

    [JsonPropertyName("hostPlatformType")]
    public HostPlatformTypeConstant? HostPlatformType { get; set; }

    [JsonPropertyName("kubernetesClusterInfo")]
    [Required]
    public KubernetesClusterInfoModel KubernetesClusterInfo { get; set; }

    [JsonPropertyName("kubernetesRoleResources")]
    [Required]
    public KubernetesRoleResourcesModel KubernetesRoleResources { get; set; }

    [JsonPropertyName("provisioningState")]
    public KubernetesStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("roleStatus")]
    [Required]
    public RoleStatusConstant RoleStatus { get; set; }
}
