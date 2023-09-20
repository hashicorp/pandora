// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class Win32LobAppProductCodeRuleModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productCode")]
    public string? ProductCode { get; set; }

    [JsonPropertyName("productVersion")]
    public string? ProductVersion { get; set; }

    [JsonPropertyName("productVersionOperator")]
    public Win32LobAppProductCodeRuleProductVersionOperatorConstant? ProductVersionOperator { get; set; }

    [JsonPropertyName("ruleType")]
    public Win32LobAppProductCodeRuleRuleTypeConstant? RuleType { get; set; }
}
