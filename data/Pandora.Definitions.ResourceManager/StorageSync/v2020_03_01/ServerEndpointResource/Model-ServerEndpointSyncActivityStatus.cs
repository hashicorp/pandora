using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;


internal class ServerEndpointSyncActivityStatusModel
{
    [JsonPropertyName("appliedBytes")]
    public int? AppliedBytes { get; set; }

    [JsonPropertyName("appliedItemCount")]
    public int? AppliedItemCount { get; set; }

    [JsonPropertyName("perItemErrorCount")]
    public int? PerItemErrorCount { get; set; }

    [JsonPropertyName("syncMode")]
    public ServerEndpointSyncModeConstant? SyncMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("totalBytes")]
    public int? TotalBytes { get; set; }

    [JsonPropertyName("totalItemCount")]
    public int? TotalItemCount { get; set; }
}
