// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Win32LobAppFileSystemRuleModel
{
    [JsonPropertyName("check32BitOn64System")]
    public bool? Check32BitOn64System { get; set; }

    [JsonPropertyName("comparisonValue")]
    public string? ComparisonValue { get; set; }

    [JsonPropertyName("fileOrFolderName")]
    public string? FileOrFolderName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operationType")]
    public Win32LobAppFileSystemRuleOperationTypeConstant? OperationType { get; set; }

    [JsonPropertyName("operator")]
    public Win32LobAppFileSystemRuleOperatorConstant? Operator { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("ruleType")]
    public Win32LobAppFileSystemRuleRuleTypeConstant? RuleType { get; set; }
}
