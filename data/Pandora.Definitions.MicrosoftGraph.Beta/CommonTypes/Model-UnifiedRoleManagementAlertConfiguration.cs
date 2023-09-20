// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleManagementAlertConfigurationModel
{
    [JsonPropertyName("alertDefinition")]
    public UnifiedRoleManagementAlertDefinitionModel? AlertDefinition { get; set; }

    [JsonPropertyName("alertDefinitionId")]
    public string? AlertDefinitionId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scopeId")]
    public string? ScopeId { get; set; }

    [JsonPropertyName("scopeType")]
    public string? ScopeType { get; set; }
}
