// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MobilityManagementPolicyModel
{
    [JsonPropertyName("appliesTo")]
    public MobilityManagementPolicyAppliesToConstant? AppliesTo { get; set; }

    [JsonPropertyName("complianceUrl")]
    public string? ComplianceUrl { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("discoveryUrl")]
    public string? DiscoveryUrl { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includedGroups")]
    public List<GroupModel>? IncludedGroups { get; set; }

    [JsonPropertyName("isValid")]
    public bool? IsValid { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("termsOfUseUrl")]
    public string? TermsOfUseUrl { get; set; }
}
