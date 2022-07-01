using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.LiveOutputs;


internal class LiveOutputPropertiesModel
{
    [JsonPropertyName("archiveWindowLength")]
    [Required]
    public string ArchiveWindowLength { get; set; }

    [JsonPropertyName("assetName")]
    [Required]
    public string AssetName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("hls")]
    public HlsModel? Hls { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("manifestName")]
    public string? ManifestName { get; set; }

    [JsonPropertyName("outputSnapTime")]
    public int? OutputSnapTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceState")]
    public LiveOutputResourceStateConstant? ResourceState { get; set; }
}
