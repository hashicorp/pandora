using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2022_09_01.ContainerInstance;


internal class CapabilitiesModel
{
    [JsonPropertyName("capabilities")]
    public CapabilitiesCapabilitiesModel? Capabilities { get; set; }

    [JsonPropertyName("gpu")]
    public string? Gpu { get; set; }

    [JsonPropertyName("ipAddressType")]
    public string? IPAddressType { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }
}
