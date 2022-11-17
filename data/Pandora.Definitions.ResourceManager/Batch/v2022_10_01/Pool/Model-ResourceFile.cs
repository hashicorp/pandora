using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.Pool;


internal class ResourceFileModel
{
    [JsonPropertyName("autoStorageContainerName")]
    public string? AutoStorageContainerName { get; set; }

    [JsonPropertyName("blobPrefix")]
    public string? BlobPrefix { get; set; }

    [JsonPropertyName("fileMode")]
    public string? FileMode { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("httpUrl")]
    public string? HTTPUrl { get; set; }

    [JsonPropertyName("identityReference")]
    public ComputeNodeIdentityReferenceModel? IdentityReference { get; set; }

    [JsonPropertyName("storageContainerUrl")]
    public string? StorageContainerUrl { get; set; }
}
