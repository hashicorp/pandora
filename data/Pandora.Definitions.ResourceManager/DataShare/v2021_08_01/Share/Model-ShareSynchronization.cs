using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Share;


internal class ShareSynchronizationModel
{
    [JsonPropertyName("consumerEmail")]
    public string? ConsumerEmail { get; set; }

    [JsonPropertyName("consumerName")]
    public string? ConsumerName { get; set; }

    [JsonPropertyName("consumerTenantName")]
    public string? ConsumerTenantName { get; set; }

    [JsonPropertyName("durationMs")]
    public int? DurationMs { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("synchronizationId")]
    public string? SynchronizationId { get; set; }

    [JsonPropertyName("synchronizationMode")]
    public SynchronizationModeConstant? SynchronizationMode { get; set; }
}
