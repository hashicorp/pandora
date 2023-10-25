using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.SyncGroups;


internal class SyncGroupLogPropertiesModel
{
    [JsonPropertyName("details")]
    public string? Details { get; set; }

    [JsonPropertyName("operationStatus")]
    public string? OperationStatus { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("tracingId")]
    public string? TracingId { get; set; }

    [JsonPropertyName("type")]
    public SyncGroupLogTypeConstant? Type { get; set; }
}
