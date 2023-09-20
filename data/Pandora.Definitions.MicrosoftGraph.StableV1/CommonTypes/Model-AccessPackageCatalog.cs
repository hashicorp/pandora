// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageCatalogModel
{
    [JsonPropertyName("accessPackages")]
    public List<AccessPackageModel>? AccessPackages { get; set; }

    [JsonPropertyName("catalogType")]
    public AccessPackageCatalogCatalogTypeConstant? CatalogType { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customWorkflowExtensions")]
    public List<CustomCalloutExtensionModel>? CustomWorkflowExtensions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isExternallyVisible")]
    public bool? IsExternallyVisible { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceRoles")]
    public List<AccessPackageResourceRoleModel>? ResourceRoles { get; set; }

    [JsonPropertyName("resourceScopes")]
    public List<AccessPackageResourceScopeModel>? ResourceScopes { get; set; }

    [JsonPropertyName("resources")]
    public List<AccessPackageResourceModel>? Resources { get; set; }

    [JsonPropertyName("state")]
    public AccessPackageCatalogStateConstant? State { get; set; }
}
