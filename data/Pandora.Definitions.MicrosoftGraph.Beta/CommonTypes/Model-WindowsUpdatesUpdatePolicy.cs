// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdatesUpdatePolicyModel
{
    [JsonPropertyName("audience")]
    public WindowsUpdatesDeploymentAudienceModel? Audience { get; set; }

    [JsonPropertyName("complianceChangeRules")]
    public List<WindowsUpdatesComplianceChangeRuleModel>? ComplianceChangeRules { get; set; }

    [JsonPropertyName("complianceChanges")]
    public List<WindowsUpdatesComplianceChangeModel>? ComplianceChanges { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deploymentSettings")]
    public WindowsUpdatesDeploymentSettingsModel? DeploymentSettings { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
