using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Addons;


internal class IoTAddonPropertiesModel
{
    [JsonPropertyName("hostPlatform")]
    public PlatformTypeConstant? HostPlatform { get; set; }

    [JsonPropertyName("hostPlatformType")]
    public HostPlatformTypeConstant? HostPlatformType { get; set; }

    [JsonPropertyName("ioTDeviceDetails")]
    [Required]
    public IoTDeviceInfoModel IoTDeviceDetails { get; set; }

    [JsonPropertyName("ioTEdgeDeviceDetails")]
    [Required]
    public IoTDeviceInfoModel IoTEdgeDeviceDetails { get; set; }

    [JsonPropertyName("provisioningState")]
    public AddonStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
