// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagementTemplateModel
{
    [JsonPropertyName("category")]
    public ManagedTenantsManagementTemplateCategoryConstant? Category { get; set; }

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

    [JsonPropertyName("informationLinks")]
    public List<ActionUrlModel>? InformationLinks { get; set; }

    [JsonPropertyName("lastActionByUserId")]
    public string? LastActionByUserId { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("managementTemplateCollections")]
    public List<ManagedTenantsManagementTemplateCollectionModel>? ManagementTemplateCollections { get; set; }

    [JsonPropertyName("managementTemplateSteps")]
    public List<ManagedTenantsManagementTemplateStepModel>? ManagementTemplateSteps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parameters")]
    public List<ManagedTenantsTemplateParameterModel>? Parameters { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("provider")]
    public ManagedTenantsManagementTemplateProviderConstant? Provider { get; set; }

    [JsonPropertyName("userImpact")]
    public string? UserImpact { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("workloadActions")]
    public List<ManagedTenantsWorkloadActionModel>? WorkloadActions { get; set; }
}
