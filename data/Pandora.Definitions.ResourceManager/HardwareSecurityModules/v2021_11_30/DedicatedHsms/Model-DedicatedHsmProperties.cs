using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2021_11_30.DedicatedHsms;


internal class DedicatedHsmPropertiesModel
{
    [JsonPropertyName("managementNetworkProfile")]
    public NetworkProfileModel? ManagementNetworkProfile { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("provisioningState")]
    public JsonWebKeyTypeConstant? ProvisioningState { get; set; }

    [JsonPropertyName("stampId")]
    public string? StampId { get; set; }

    [JsonPropertyName("statusMessage")]
    public string? StatusMessage { get; set; }
}
