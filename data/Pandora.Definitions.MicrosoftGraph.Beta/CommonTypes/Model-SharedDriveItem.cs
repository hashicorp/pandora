// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SharedDriveItemModel
{
    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdByUser")]
    public UserModel? CreatedByUser { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("driveItem")]
    public DriveItemModel? DriveItem { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("items")]
    public List<DriveItemModel>? Items { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedByUser")]
    public UserModel? LastModifiedByUser { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("list")]
    public ListModel? List { get; set; }

    [JsonPropertyName("listItem")]
    public ListItemModel? ListItem { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public IdentitySetModel? Owner { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("permission")]
    public PermissionModel? Permission { get; set; }

    [JsonPropertyName("root")]
    public DriveItemModel? Root { get; set; }

    [JsonPropertyName("site")]
    public SiteModel? Site { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
