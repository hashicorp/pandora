using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.Pool;


internal class AzureBlobFileSystemConfigurationModel
{
    [JsonPropertyName("accountKey")]
    public string? AccountKey { get; set; }

    [JsonPropertyName("accountName")]
    [Required]
    public string AccountName { get; set; }

    [JsonPropertyName("blobfuseOptions")]
    public string? BlobfuseOptions { get; set; }

    [JsonPropertyName("containerName")]
    [Required]
    public string ContainerName { get; set; }

    [JsonPropertyName("identityReference")]
    public ComputeNodeIdentityReferenceModel? IdentityReference { get; set; }

    [JsonPropertyName("relativeMountPath")]
    [Required]
    public string RelativeMountPath { get; set; }

    [JsonPropertyName("sasKey")]
    public string? SasKey { get; set; }
}
