using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.CloudEndpointResource;


internal class CloudEndpointLastChangeEnumerationStatusModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("completedTimestamp")]
    public DateTime? CompletedTimestamp { get; set; }

    [JsonPropertyName("namespaceDirectoriesCount")]
    public int? NamespaceDirectoriesCount { get; set; }

    [JsonPropertyName("namespaceFilesCount")]
    public int? NamespaceFilesCount { get; set; }

    [JsonPropertyName("namespaceSizeBytes")]
    public int? NamespaceSizeBytes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextRunTimestamp")]
    public DateTime? NextRunTimestamp { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startedTimestamp")]
    public DateTime? StartedTimestamp { get; set; }
}
