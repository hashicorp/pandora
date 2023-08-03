// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class Win32LobAppRegistryRuleModel
{
    [JsonPropertyName("check32BitOn64System")]
    public bool? Check32BitOn64System { get; set; }

    [JsonPropertyName("comparisonValue")]
    public string? ComparisonValue { get; set; }

    [JsonPropertyName("keyPath")]
    public string? KeyPath { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operationType")]
    public Win32LobAppRegistryRuleOperationTypeConstant? OperationType { get; set; }

    [JsonPropertyName("operator")]
    public Win32LobAppRuleOperatorConstant? Operator { get; set; }

    [JsonPropertyName("ruleType")]
    public Win32LobAppRuleTypeConstant? RuleType { get; set; }

    [JsonPropertyName("valueName")]
    public string? ValueName { get; set; }
}
