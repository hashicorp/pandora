// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagementTemplateCollectionTenantSummaryModel
{
    [JsonPropertyName("completeStepsCount")]
    public int? CompleteStepsCount { get; set; }

    [JsonPropertyName("completeUsersCount")]
    public int? CompleteUsersCount { get; set; }

    [JsonPropertyName("createdByUserId")]
    public string? CreatedByUserId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dismissedStepsCount")]
    public int? DismissedStepsCount { get; set; }

    [JsonPropertyName("excludedUsersCount")]
    public int? ExcludedUsersCount { get; set; }

    [JsonPropertyName("excludedUsersDistinctCount")]
    public int? ExcludedUsersDistinctCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incompleteStepsCount")]
    public int? IncompleteStepsCount { get; set; }

    [JsonPropertyName("incompleteUsersCount")]
    public int? IncompleteUsersCount { get; set; }

    [JsonPropertyName("ineligibleStepsCount")]
    public int? IneligibleStepsCount { get; set; }

    [JsonPropertyName("isComplete")]
    public bool? IsComplete { get; set; }

    [JsonPropertyName("lastActionByUserId")]
    public string? LastActionByUserId { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("managementTemplateCollectionDisplayName")]
    public string? ManagementTemplateCollectionDisplayName { get; set; }

    [JsonPropertyName("managementTemplateCollectionId")]
    public string? ManagementTemplateCollectionId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("regressedStepsCount")]
    public int? RegressedStepsCount { get; set; }

    [JsonPropertyName("regressedUsersCount")]
    public int? RegressedUsersCount { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("unlicensedUsersCount")]
    public int? UnlicensedUsersCount { get; set; }
}
