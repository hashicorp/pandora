using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Roles;


internal class IoTRolePropertiesModel
{
    [JsonPropertyName("computeResource")]
    public ComputeResourceModel? ComputeResource { get; set; }

    [JsonPropertyName("hostPlatform")]
    [Required]
    public PlatformTypeConstant HostPlatform { get; set; }

    [JsonPropertyName("hostPlatformType")]
    public HostPlatformTypeConstant? HostPlatformType { get; set; }

    [JsonPropertyName("ioTDeviceDetails")]
    [Required]
    public IoTDeviceInfoModel IoTDeviceDetails { get; set; }

    [JsonPropertyName("ioTEdgeAgentInfo")]
    public IoTEdgeAgentInfoModel? IoTEdgeAgentInfo { get; set; }

    [JsonPropertyName("ioTEdgeDeviceDetails")]
    [Required]
    public IoTDeviceInfoModel IoTEdgeDeviceDetails { get; set; }

    [JsonPropertyName("roleStatus")]
    [Required]
    public RoleStatusConstant RoleStatus { get; set; }

    [JsonPropertyName("shareMappings")]
    public List<MountPointMapModel>? ShareMappings { get; set; }
}
