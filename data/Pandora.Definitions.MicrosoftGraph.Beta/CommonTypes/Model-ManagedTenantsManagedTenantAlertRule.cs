// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagedTenantAlertRuleModel
{
    [JsonPropertyName("alertDisplayName")]
    public string? AlertDisplayName { get; set; }

    [JsonPropertyName("alertTTL")]
    public int? AlertTTL { get; set; }

    [JsonPropertyName("alerts")]
    public List<ManagedTenantsManagedTenantAlertModel>? Alerts { get; set; }

    [JsonPropertyName("createdByUserId")]
    public string? CreatedByUserId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActionByUserId")]
    public string? LastActionByUserId { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("lastRunDateTime")]
    public DateTime? LastRunDateTime { get; set; }

    [JsonPropertyName("notificationFinalDestinations")]
    public ManagedTenantsManagedTenantAlertRuleNotificationFinalDestinationsConstant? NotificationFinalDestinations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ruleDefinition")]
    public ManagedTenantsManagedTenantAlertRuleDefinitionModel? RuleDefinition { get; set; }

    [JsonPropertyName("severity")]
    public ManagedTenantsManagedTenantAlertRuleSeverityConstant? Severity { get; set; }

    [JsonPropertyName("targets")]
    public List<ManagedTenantsNotificationTargetModel>? Targets { get; set; }

    [JsonPropertyName("tenantIds")]
    public List<ManagedTenantsTenantInfoModel>? TenantIds { get; set; }
}
