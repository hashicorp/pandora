// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementAlertRuleModel
{
    [JsonPropertyName("alertRuleTemplate")]
    public DeviceManagementAlertRuleAlertRuleTemplateConstant? AlertRuleTemplate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isSystemRule")]
    public bool? IsSystemRule { get; set; }

    [JsonPropertyName("notificationChannels")]
    public List<DeviceManagementNotificationChannelModel>? NotificationChannels { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("severity")]
    public DeviceManagementAlertRuleSeverityConstant? Severity { get; set; }

    [JsonPropertyName("threshold")]
    public DeviceManagementRuleThresholdModel? Threshold { get; set; }
}
