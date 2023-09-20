// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BusinessFlowModel
{
    [JsonPropertyName("customData")]
    public string? CustomData { get; set; }

    [JsonPropertyName("deDuplicationId")]
    public string? DeDuplicationId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policy")]
    public GovernancePolicyModel? Policy { get; set; }

    [JsonPropertyName("policyTemplateId")]
    public string? PolicyTemplateId { get; set; }

    [JsonPropertyName("recordVersion")]
    public string? RecordVersion { get; set; }

    [JsonPropertyName("schemaId")]
    public string? SchemaId { get; set; }

    [JsonPropertyName("settings")]
    public BusinessFlowSettingsModel? Settings { get; set; }
}
