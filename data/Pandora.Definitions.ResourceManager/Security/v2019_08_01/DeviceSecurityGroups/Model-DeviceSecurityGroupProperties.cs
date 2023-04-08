using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.DeviceSecurityGroups;


internal class DeviceSecurityGroupPropertiesModel
{
    [JsonPropertyName("allowlistRules")]
    public List<AllowlistCustomAlertRuleModel>? AllowlistRules { get; set; }

    [JsonPropertyName("denylistRules")]
    public List<DenylistCustomAlertRuleModel>? DenylistRules { get; set; }

    [JsonPropertyName("thresholdRules")]
    public List<ThresholdCustomAlertRuleModel>? ThresholdRules { get; set; }

    [JsonPropertyName("timeWindowRules")]
    public List<TimeWindowCustomAlertRuleModel>? TimeWindowRules { get; set; }
}
