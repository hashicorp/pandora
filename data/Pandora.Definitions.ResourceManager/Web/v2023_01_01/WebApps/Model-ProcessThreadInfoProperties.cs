using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class ProcessThreadInfoPropertiesModel
{
    [JsonPropertyName("base_priority")]
    public int? BasePriority { get; set; }

    [JsonPropertyName("current_priority")]
    public int? CurrentPriority { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("identifier")]
    public int? Identifier { get; set; }

    [JsonPropertyName("priority_level")]
    public string? PriorityLevel { get; set; }

    [JsonPropertyName("process")]
    public string? Process { get; set; }

    [JsonPropertyName("start_address")]
    public string? StartAddress { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("start_time")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("total_processor_time")]
    public string? TotalProcessorTime { get; set; }

    [JsonPropertyName("user_processor_time")]
    public string? UserProcessorTime { get; set; }

    [JsonPropertyName("wait_reason")]
    public string? WaitReason { get; set; }
}
