// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SitePageModel
{
    [JsonPropertyName("canvasLayout")]
    public CanvasLayoutModel? CanvasLayout { get; set; }

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

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

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

    [JsonPropertyName("pageLayout")]
    public PageLayoutTypeConstant? PageLayout { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("promotionKind")]
    public PagePromotionTypeConstant? PromotionKind { get; set; }

    [JsonPropertyName("publishingState")]
    public PublicationFacetModel? PublishingState { get; set; }

    [JsonPropertyName("reactions")]
    public ReactionsFacetModel? Reactions { get; set; }

    [JsonPropertyName("showComments")]
    public bool? ShowComments { get; set; }

    [JsonPropertyName("showRecommendedPages")]
    public bool? ShowRecommendedPages { get; set; }

    [JsonPropertyName("thumbnailWebUrl")]
    public string? ThumbnailWebUrl { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("titleArea")]
    public TitleAreaModel? TitleArea { get; set; }

    [JsonPropertyName("webParts")]
    public List<WebPartModel>? WebParts { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
