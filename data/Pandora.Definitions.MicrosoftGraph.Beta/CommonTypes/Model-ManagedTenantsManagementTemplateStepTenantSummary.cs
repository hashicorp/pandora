// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagementTemplateStepTenantSummaryModel
{
    [JsonPropertyName("assignedTenantsCount")]
    public int? AssignedTenantsCount { get; set; }

    [JsonPropertyName("compliantTenantsCount")]
    public int? CompliantTenantsCount { get; set; }

    [JsonPropertyName("createdByUserId")]
    public string? CreatedByUserId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dismissedTenantsCount")]
    public int? DismissedTenantsCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ineligibleTenantsCount")]
    public int? IneligibleTenantsCount { get; set; }

    [JsonPropertyName("lastActionByUserId")]
    public string? LastActionByUserId { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("managementTemplateCollectionDisplayName")]
    public string? ManagementTemplateCollectionDisplayName { get; set; }

    [JsonPropertyName("managementTemplateCollectionId")]
    public string? ManagementTemplateCollectionId { get; set; }

    [JsonPropertyName("managementTemplateDisplayName")]
    public string? ManagementTemplateDisplayName { get; set; }

    [JsonPropertyName("managementTemplateId")]
    public string? ManagementTemplateId { get; set; }

    [JsonPropertyName("managementTemplateStepDisplayName")]
    public string? ManagementTemplateStepDisplayName { get; set; }

    [JsonPropertyName("managementTemplateStepId")]
    public string? ManagementTemplateStepId { get; set; }

    [JsonPropertyName("notCompliantTenantsCount")]
    public int? NotCompliantTenantsCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
