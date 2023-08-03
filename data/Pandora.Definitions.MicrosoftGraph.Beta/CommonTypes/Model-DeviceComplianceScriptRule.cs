// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceComplianceScriptRuleModel
{
    [JsonPropertyName("dataType")]
    public DataTypeConstant? DataType { get; set; }

    [JsonPropertyName("deviceComplianceScriptRulOperator")]
    public DeviceComplianceScriptRulOperatorConstant? DeviceComplianceScriptRulOperator { get; set; }

    [JsonPropertyName("deviceComplianceScriptRuleDataType")]
    public DeviceComplianceScriptRuleDataTypeConstant? DeviceComplianceScriptRuleDataType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operand")]
    public string? Operand { get; set; }

    [JsonPropertyName("operator")]
    public OperatorConstant? Operator { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }
}
