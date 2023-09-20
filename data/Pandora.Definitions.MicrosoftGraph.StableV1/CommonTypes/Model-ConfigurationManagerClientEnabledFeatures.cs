// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConfigurationManagerClientEnabledFeaturesModel
{
    [JsonPropertyName("compliancePolicy")]
    public bool? CompliancePolicy { get; set; }

    [JsonPropertyName("deviceConfiguration")]
    public bool? DeviceConfiguration { get; set; }

    [JsonPropertyName("inventory")]
    public bool? Inventory { get; set; }

    [JsonPropertyName("modernApps")]
    public bool? ModernApps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceAccess")]
    public bool? ResourceAccess { get; set; }

    [JsonPropertyName("windowsUpdateForBusiness")]
    public bool? WindowsUpdateForBusiness { get; set; }
}
