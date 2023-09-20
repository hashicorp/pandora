// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SensitivityLabelModel
{
    [JsonPropertyName("applicableTo")]
    public SensitivityLabelApplicableToConstant? ApplicableTo { get; set; }

    [JsonPropertyName("applicationMode")]
    public SensitivityLabelApplicationModeConstant? ApplicationMode { get; set; }

    [JsonPropertyName("assignedPolicies")]
    public List<LabelPolicyModel>? AssignedPolicies { get; set; }

    [JsonPropertyName("autoLabeling")]
    public AutoLabelingModel? AutoLabeling { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("isEndpointProtectionEnabled")]
    public bool? IsEndpointProtectionEnabled { get; set; }

    [JsonPropertyName("labelActions")]
    public List<LabelActionBaseModel>? LabelActions { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("sublabels")]
    public List<SensitivityLabelModel>? Sublabels { get; set; }

    [JsonPropertyName("toolTip")]
    public string? ToolTip { get; set; }
}
