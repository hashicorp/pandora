// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageCatalogModel
{
    [JsonPropertyName("accessPackageCustomWorkflowExtensions")]
    public List<CustomCalloutExtensionModel>? AccessPackageCustomWorkflowExtensions { get; set; }

    [JsonPropertyName("accessPackageResourceRoles")]
    public List<AccessPackageResourceRoleModel>? AccessPackageResourceRoles { get; set; }

    [JsonPropertyName("accessPackageResourceScopes")]
    public List<AccessPackageResourceScopeModel>? AccessPackageResourceScopes { get; set; }

    [JsonPropertyName("accessPackageResources")]
    public List<AccessPackageResourceModel>? AccessPackageResources { get; set; }

    [JsonPropertyName("accessPackages")]
    public List<AccessPackageModel>? AccessPackages { get; set; }

    [JsonPropertyName("catalogStatus")]
    public string? CatalogStatus { get; set; }

    [JsonPropertyName("catalogType")]
    public string? CatalogType { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customAccessPackageWorkflowExtensions")]
    public List<CustomAccessPackageWorkflowExtensionModel>? CustomAccessPackageWorkflowExtensions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isExternallyVisible")]
    public bool? IsExternallyVisible { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
