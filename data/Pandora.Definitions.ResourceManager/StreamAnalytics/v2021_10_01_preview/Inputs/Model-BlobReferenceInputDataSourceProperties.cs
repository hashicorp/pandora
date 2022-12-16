using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Inputs;


internal class BlobReferenceInputDataSourcePropertiesModel
{
    [JsonPropertyName("authenticationMode")]
    public AuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("blobName")]
    public string? BlobName { get; set; }

    [JsonPropertyName("container")]
    public string? Container { get; set; }

    [JsonPropertyName("dateFormat")]
    public string? DateFormat { get; set; }

    [JsonPropertyName("deltaPathPattern")]
    public string? DeltaPathPattern { get; set; }

    [JsonPropertyName("deltaSnapshotRefreshRate")]
    public string? DeltaSnapshotRefreshRate { get; set; }

    [JsonPropertyName("fullSnapshotRefreshRate")]
    public string? FullSnapshotRefreshRate { get; set; }

    [JsonPropertyName("pathPattern")]
    public string? PathPattern { get; set; }

    [JsonPropertyName("sourcePartitionCount")]
    public int? SourcePartitionCount { get; set; }

    [JsonPropertyName("storageAccounts")]
    public List<StorageAccountModel>? StorageAccounts { get; set; }

    [JsonPropertyName("timeFormat")]
    public string? TimeFormat { get; set; }
}
