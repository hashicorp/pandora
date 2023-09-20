// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsManagementTemplateStepModel
{
    [JsonPropertyName("acceptedVersion")]
    public ManagedTenantsManagementTemplateStepVersionModel? AcceptedVersion { get; set; }

    [JsonPropertyName("category")]
    public ManagedTenantsManagementTemplateStepCategoryConstant? Category { get; set; }

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

    [JsonPropertyName("managementTemplate")]
    public ManagedTenantsManagementTemplateModel? ManagementTemplate { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("portalLink")]
    public ActionUrlModel? PortalLink { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("versions")]
    public List<ManagedTenantsManagementTemplateStepVersionModel>? Versions { get; set; }
}
