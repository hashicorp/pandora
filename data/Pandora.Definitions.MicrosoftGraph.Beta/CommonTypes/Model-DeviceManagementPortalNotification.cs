// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementPortalNotificationModel
{
    [JsonPropertyName("alertImpact")]
    public DeviceManagementAlertImpactModel? AlertImpact { get; set; }

    [JsonPropertyName("alertRecordId")]
    public string? AlertRecordId { get; set; }

    [JsonPropertyName("alertRuleId")]
    public string? AlertRuleId { get; set; }

    [JsonPropertyName("alertRuleName")]
    public string? AlertRuleName { get; set; }

    [JsonPropertyName("alertRuleTemplate")]
    public DeviceManagementPortalNotificationAlertRuleTemplateConstant? AlertRuleTemplate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isPortalNotificationSent")]
    public bool? IsPortalNotificationSent { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("severity")]
    public DeviceManagementPortalNotificationSeverityConstant? Severity { get; set; }
}
