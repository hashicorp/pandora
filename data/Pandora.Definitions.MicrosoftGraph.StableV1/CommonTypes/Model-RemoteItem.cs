// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class RemoteItemModel
{
    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

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

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("package")]
    public PackageModel? Package { get; set; }

    [JsonPropertyName("parentReference")]
    public ItemReferenceModel? ParentReference { get; set; }

    [JsonPropertyName("shared")]
    public SharedModel? Shared { get; set; }

    [JsonPropertyName("sharepointIds")]
    public SharepointIdsModel? SharepointIds { get; set; }

    [JsonPropertyName("size")]
    public long? Size { get; set; }

    [JsonPropertyName("specialFolder")]
    public SpecialFolderModel? SpecialFolder { get; set; }

    [JsonPropertyName("video")]
    public VideoModel? Video { get; set; }

    [JsonPropertyName("webDavUrl")]
    public string? WebDavUrl { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
