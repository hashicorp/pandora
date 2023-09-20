// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Win32LobAppPowerShellScriptRuleModel
{
    [JsonPropertyName("comparisonValue")]
    public string? ComparisonValue { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enforceSignatureCheck")]
    public bool? EnforceSignatureCheck { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operationType")]
    public Win32LobAppPowerShellScriptRuleOperationTypeConstant? OperationType { get; set; }

    [JsonPropertyName("operator")]
    public Win32LobAppPowerShellScriptRuleOperatorConstant? Operator { get; set; }

    [JsonPropertyName("ruleType")]
    public Win32LobAppPowerShellScriptRuleRuleTypeConstant? RuleType { get; set; }

    [JsonPropertyName("runAs32Bit")]
    public bool? RunAs32Bit { get; set; }

    [JsonPropertyName("runAsAccount")]
    public Win32LobAppPowerShellScriptRuleRunAsAccountConstant? RunAsAccount { get; set; }

    [JsonPropertyName("scriptContent")]
    public string? ScriptContent { get; set; }
}
