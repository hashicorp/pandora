// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class InformationProtectionModel
{
    [JsonPropertyName("bitlocker")]
    public BitlockerModel? Bitlocker { get; set; }

    [JsonPropertyName("dataLossPreventionPolicies")]
    public List<DataLossPreventionPolicyModel>? DataLossPreventionPolicies { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policy")]
    public InformationProtectionPolicyModel? Policy { get; set; }

    [JsonPropertyName("sensitivityLabels")]
    public List<SensitivityLabelModel>? SensitivityLabels { get; set; }

    [JsonPropertyName("sensitivityPolicySettings")]
    public SensitivityPolicySettingsModel? SensitivityPolicySettings { get; set; }

    [JsonPropertyName("threatAssessmentRequests")]
    public List<ThreatAssessmentRequestModel>? ThreatAssessmentRequests { get; set; }
}
