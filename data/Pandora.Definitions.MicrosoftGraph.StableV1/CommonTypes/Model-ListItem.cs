// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ListItemModel
{
    [JsonPropertyName("analytics")]
    public ItemAnalyticsModel? Analytics { get; set; }

    [JsonPropertyName("contentType")]
    public ContentTypeInfoModel? ContentType { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdByUser")]
    public UserModel? CreatedByUser { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("documentSetVersions")]
    public List<DocumentSetVersionModel>? DocumentSetVersions { get; set; }

    [JsonPropertyName("driveItem")]
    public DriveItemModel? DriveItem { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("fields")]
    public FieldValueSetModel? Fields { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedByUser")]
    public UserModel? LastModifiedByUser { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("sharepointIds")]
    public SharepointIdsModel? SharepointIds { get; set; }

    [JsonPropertyName("versions")]
    public List<ListItemVersionModel>? Versions { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
