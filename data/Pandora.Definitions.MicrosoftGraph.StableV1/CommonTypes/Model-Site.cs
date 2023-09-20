// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SiteModel
{
    [JsonPropertyName("analytics")]
    public ItemAnalyticsModel? Analytics { get; set; }

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

    [JsonPropertyName("drives")]
    public List<DriveModel>? Drives { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("error")]
    public PublicErrorModel? Error { get; set; }

    [JsonPropertyName("externalColumns")]
    public List<ColumnDefinitionModel>? ExternalColumns { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isPersonalSite")]
    public bool? IsPersonalSite { get; set; }

    [JsonPropertyName("items")]
    public List<BaseItemModel>? Items { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedByUser")]
    public UserModel? LastModifiedByUser { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lists")]
    public List<ListModel>? Lists { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onenote")]
    public OnenoteModel? Onenote { get; set; }

    [JsonPropertyName("operations")]
    public List<RichLongRunningOperationModel>? Operations { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("permissions")]
    public List<PermissionModel>? Permissions { get; set; }

    [JsonPropertyName("root")]
    public RootModel? Root { get; set; }

    [JsonPropertyName("sharepointIds")]
    public SharepointIdsModel? SharepointIds { get; set; }

    [JsonPropertyName("siteCollection")]
    public SiteCollectionModel? SiteCollection { get; set; }

    [JsonPropertyName("sites")]
    public List<SiteModel>? Sites { get; set; }

    [JsonPropertyName("termStore")]
    public TermStoreStoreModel? TermStore { get; set; }

    [JsonPropertyName("termStores")]
    public List<TermStoreStoreModel>? TermStores { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
