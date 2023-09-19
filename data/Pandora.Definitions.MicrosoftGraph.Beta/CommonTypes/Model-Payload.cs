// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PayloadModel
{
    [JsonPropertyName("brand")]
    public PayloadBrandConstant? Brand { get; set; }

    [JsonPropertyName("complexity")]
    public PayloadComplexityConstant? Complexity { get; set; }

    [JsonPropertyName("createdBy")]
    public EmailIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detail")]
    public PayloadDetailModel? Detail { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("industry")]
    public PayloadIndustryConstant? Industry { get; set; }

    [JsonPropertyName("isAutomated")]
    public bool? IsAutomated { get; set; }

    [JsonPropertyName("isControversial")]
    public bool? IsControversial { get; set; }

    [JsonPropertyName("isCurrentEvent")]
    public bool? IsCurrentEvent { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public EmailIdentityModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payloadTags")]
    public List<string>? PayloadTags { get; set; }

    [JsonPropertyName("platform")]
    public PayloadPlatformConstant? Platform { get; set; }

    [JsonPropertyName("simulationAttackType")]
    public PayloadSimulationAttackTypeConstant? SimulationAttackType { get; set; }

    [JsonPropertyName("source")]
    public PayloadSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public PayloadStatusConstant? Status { get; set; }

    [JsonPropertyName("technique")]
    public PayloadTechniqueConstant? Technique { get; set; }

    [JsonPropertyName("theme")]
    public PayloadThemeConstant? Theme { get; set; }
}
