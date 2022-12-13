using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.Entities;


internal class EntityInfoPropertiesModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("inheritedPermissions")]
    public PermissionsConstant? InheritedPermissions { get; set; }

    [JsonPropertyName("numberOfChildGroups")]
    public int? NumberOfChildGroups { get; set; }

    [JsonPropertyName("numberOfChildren")]
    public int? NumberOfChildren { get; set; }

    [JsonPropertyName("numberOfDescendants")]
    public int? NumberOfDescendants { get; set; }

    [JsonPropertyName("parent")]
    public EntityParentGroupInfoModel? Parent { get; set; }

    [JsonPropertyName("parentDisplayNameChain")]
    public List<string>? ParentDisplayNameChain { get; set; }

    [JsonPropertyName("parentNameChain")]
    public List<string>? ParentNameChain { get; set; }

    [JsonPropertyName("permissions")]
    public PermissionsConstant? Permissions { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
