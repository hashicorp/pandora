using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;


internal class ServerEndpointSyncSessionStatusModel
{
    [JsonPropertyName("filesNotSyncingErrors")]
    public List<ServerEndpointFilesNotSyncingErrorModel>? FilesNotSyncingErrors { get; set; }

    [JsonPropertyName("lastSyncMode")]
    public ServerEndpointSyncModeConstant? LastSyncMode { get; set; }

    [JsonPropertyName("lastSyncPerItemErrorCount")]
    public int? LastSyncPerItemErrorCount { get; set; }

    [JsonPropertyName("lastSyncResult")]
    public int? LastSyncResult { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSyncSuccessTimestamp")]
    public DateTime? LastSyncSuccessTimestamp { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSyncTimestamp")]
    public DateTime? LastSyncTimestamp { get; set; }

    [JsonPropertyName("persistentFilesNotSyncingCount")]
    public int? PersistentFilesNotSyncingCount { get; set; }

    [JsonPropertyName("transientFilesNotSyncingCount")]
    public int? TransientFilesNotSyncingCount { get; set; }
}
