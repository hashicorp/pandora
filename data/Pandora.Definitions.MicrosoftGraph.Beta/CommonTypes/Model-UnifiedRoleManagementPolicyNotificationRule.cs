// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleManagementPolicyNotificationRuleModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefaultRecipientsEnabled")]
    public bool? IsDefaultRecipientsEnabled { get; set; }

    [JsonPropertyName("notificationLevel")]
    public string? NotificationLevel { get; set; }

    [JsonPropertyName("notificationRecipients")]
    public List<string>? NotificationRecipients { get; set; }

    [JsonPropertyName("notificationType")]
    public string? NotificationType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recipientType")]
    public string? RecipientType { get; set; }

    [JsonPropertyName("target")]
    public UnifiedRoleManagementPolicyRuleTargetModel? Target { get; set; }
}
