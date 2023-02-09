using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Share;


internal class SynchronizationDetailsModel
{
    [JsonPropertyName("dataSetId")]
    public string? DataSetId { get; set; }

    [JsonPropertyName("dataSetType")]
    public DataSetTypeConstant? DataSetType { get; set; }

    [JsonPropertyName("durationMs")]
    public int? DurationMs { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("filesRead")]
    public int? FilesRead { get; set; }

    [JsonPropertyName("filesWritten")]
    public int? FilesWritten { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("rowsCopied")]
    public int? RowsCopied { get; set; }

    [JsonPropertyName("rowsRead")]
    public int? RowsRead { get; set; }

    [JsonPropertyName("sizeRead")]
    public int? SizeRead { get; set; }

    [JsonPropertyName("sizeWritten")]
    public int? SizeWritten { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("vCore")]
    public int? VCore { get; set; }
}
