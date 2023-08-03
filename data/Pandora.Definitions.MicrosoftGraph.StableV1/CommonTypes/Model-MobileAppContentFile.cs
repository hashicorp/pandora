// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MobileAppContentFileModel
{
    [JsonPropertyName("azureStorageUri")]
    public string? AzureStorageUri { get; set; }

    [JsonPropertyName("azureStorageUriExpirationDateTime")]
    public DateTime? AzureStorageUriExpirationDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isCommitted")]
    public bool? IsCommitted { get; set; }

    [JsonPropertyName("manifest")]
    public string? Manifest { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("size")]
    public long? Size { get; set; }

    [JsonPropertyName("sizeEncrypted")]
    public long? SizeEncrypted { get; set; }

    [JsonPropertyName("uploadState")]
    public MobileAppContentFileUploadStateConstant? UploadState { get; set; }
}
