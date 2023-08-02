// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleManagementAlertDefinitionModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("howToPrevent")]
    public string? HowToPrevent { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isConfigurable")]
    public bool? IsConfigurable { get; set; }

    [JsonPropertyName("isRemediatable")]
    public bool? IsRemediatable { get; set; }

    [JsonPropertyName("mitigationSteps")]
    public string? MitigationSteps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scopeId")]
    public string? ScopeId { get; set; }

    [JsonPropertyName("scopeType")]
    public string? ScopeType { get; set; }

    [JsonPropertyName("securityImpact")]
    public string? SecurityImpact { get; set; }

    [JsonPropertyName("severityLevel")]
    public AlertSeverityConstant? SeverityLevel { get; set; }
}
