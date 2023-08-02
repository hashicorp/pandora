// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ListModel
{
    [JsonPropertyName("activities")]
    public List<ItemActivityOLDModel>? Activities { get; set; }

    [JsonPropertyName("columns")]
    public List<ColumnDefinitionModel>? Columns { get; set; }

    [JsonPropertyName("contentTypes")]
    public List<ContentTypeModel>? ContentTypes { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdByUser")]
    public UserModel? CreatedByUser { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("drive")]
    public DriveModel? Drive { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("items")]
    public List<ListItemModel>? Items { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedByUser")]
    public UserModel? LastModifiedByUser { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("list")]
    public ListInfoModel? List { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<RichLongRunningOperationModel>? Operations { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("sharepointIds")]
    public SharepointIdsModel? SharepointIds { get; set; }

    [JsonPropertyName("subscriptions")]
    public List<SubscriptionModel>? Subscriptions { get; set; }

    [JsonPropertyName("system")]
    public SystemFacetModel? System { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
