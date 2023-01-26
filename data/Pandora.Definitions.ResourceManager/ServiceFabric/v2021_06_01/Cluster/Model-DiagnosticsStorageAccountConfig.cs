using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class DiagnosticsStorageAccountConfigModel
{
    [JsonPropertyName("blobEndpoint")]
    [Required]
    public string BlobEndpoint { get; set; }

    [JsonPropertyName("protectedAccountKeyName")]
    [Required]
    public string ProtectedAccountKeyName { get; set; }

    [JsonPropertyName("protectedAccountKeyName2")]
    public string? ProtectedAccountKeyName2 { get; set; }

    [JsonPropertyName("queueEndpoint")]
    [Required]
    public string QueueEndpoint { get; set; }

    [JsonPropertyName("storageAccountName")]
    [Required]
    public string StorageAccountName { get; set; }

    [JsonPropertyName("tableEndpoint")]
    [Required]
    public string TableEndpoint { get; set; }
}
