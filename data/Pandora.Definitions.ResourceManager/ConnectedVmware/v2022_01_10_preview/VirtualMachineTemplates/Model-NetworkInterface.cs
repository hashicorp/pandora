using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachineTemplates;


internal class NetworkInterfaceModel
{
    [JsonPropertyName("deviceKey")]
    public int? DeviceKey { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("ipSettings")]
    public NicIPSettingsModel? IPSettings { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("networkId")]
    public string? NetworkId { get; set; }

    [JsonPropertyName("networkMoName")]
    public string? NetworkMoName { get; set; }

    [JsonPropertyName("networkMoRefId")]
    public string? NetworkMoRefId { get; set; }

    [JsonPropertyName("nicType")]
    public NICTypeConstant? NicType { get; set; }

    [JsonPropertyName("powerOnBoot")]
    public PowerOnBootOptionConstant? PowerOnBoot { get; set; }
}
