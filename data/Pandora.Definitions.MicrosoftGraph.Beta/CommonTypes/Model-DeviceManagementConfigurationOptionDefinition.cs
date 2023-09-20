// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementConfigurationOptionDefinitionModel
{
    [JsonPropertyName("dependedOnBy")]
    public List<DeviceManagementConfigurationSettingDependedOnByModel>? DependedOnBy { get; set; }

    [JsonPropertyName("dependentOn")]
    public List<DeviceManagementConfigurationDependentOnModel>? DependentOn { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("helpText")]
    public string? HelpText { get; set; }

    [JsonPropertyName("itemId")]
    public string? ItemId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("optionValue")]
    public DeviceManagementConfigurationSettingValueModel? OptionValue { get; set; }
}
