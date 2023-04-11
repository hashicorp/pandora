using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.DeviceSecurityGroups;


internal class DenylistCustomAlertRuleModel
{
    [JsonPropertyName("denylistValues")]
    [Required]
    public List<string> DenylistValues { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("ruleType")]
    public string? RuleType { get; set; }

    [JsonPropertyName("valueType")]
    public ValueTypeConstant? ValueType { get; set; }
}
