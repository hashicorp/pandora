// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DriveItemModel
{
    [JsonPropertyName("activities")]
    public List<ItemActivityOLDModel>? Activities { get; set; }

    [JsonPropertyName("analytics")]
    public ItemAnalyticsModel? Analytics { get; set; }

    [JsonPropertyName("audio")]
    public AudioModel? Audio { get; set; }

    [JsonPropertyName("bundle")]
    public BundleModel? Bundle { get; set; }

    [JsonPropertyName("cTag")]
    public string? CTag { get; set; }

    [JsonPropertyName("children")]
    public List<DriveItemModel>? Children { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdByUser")]
    public UserModel? CreatedByUser { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deleted")]
    public DeletedModel? Deleted { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("file")]
    public FileModel? File { get; set; }

    [JsonPropertyName("fileSystemInfo")]
    public FileSystemInfoModel? FileSystemInfo { get; set; }

    [JsonPropertyName("folder")]
    public FolderModel? Folder { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("image")]
    public ImageModel? Image { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedByUser")]
    public UserModel? LastModifiedByUser { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("listItem")]
    public ListItemModel? ListItem { get; set; }

    [JsonPropertyName("location")]
    public GeoCoordinatesModel? Location { get; set; }

    [JsonPropertyName("malware")]
    public MalwareModel? Malware { get; set; }

    [JsonPropertyName("media")]
    public MediaModel? Media { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("package")]
    public PackageModel? Package { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("pendingOperations")]
    public PendingOperationsModel? PendingOperations { get; set; }

    [JsonPropertyName("permissions")]
    public List<PermissionModel>? Permissions { get; set; }

    [JsonPropertyName("photo")]
    public PhotoModel? Photo { get; set; }

    [JsonPropertyName("publication")]
    public PublicationFacetModel? Publication { get; set; }

    [JsonPropertyName("remoteItem")]
    public RemoteItemModel? RemoteItem { get; set; }

    [JsonPropertyName("retentionLabel")]
    public ItemRetentionLabelModel? RetentionLabel { get; set; }

    [JsonPropertyName("root")]
    public RootModel? Root { get; set; }

    [JsonPropertyName("searchResult")]
    public SearchResultModel? SearchResult { get; set; }

    [JsonPropertyName("shared")]
    public SharedModel? Shared { get; set; }

    [JsonPropertyName("sharepointIds")]
    public SharepointIdsModel? SharepointIds { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("source")]
    public DriveItemSourceModel? Source { get; set; }

    [JsonPropertyName("specialFolder")]
    public SpecialFolderModel? SpecialFolder { get; set; }

    [JsonPropertyName("subscriptions")]
    public List<SubscriptionModel>? Subscriptions { get; set; }

    [JsonPropertyName("thumbnails")]
    public List<ThumbnailSetModel>? Thumbnails { get; set; }

    [JsonPropertyName("versions")]
    public List<DriveItemVersionModel>? Versions { get; set; }

    [JsonPropertyName("video")]
    public VideoModel? Video { get; set; }

    [JsonPropertyName("webDavUrl")]
    public string? WebDavUrl { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }

    [JsonPropertyName("workbook")]
    public WorkbookModel? Workbook { get; set; }
}
