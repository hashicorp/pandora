using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class TriggeredJobRunModel
{
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("end_time")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("error_url")]
    public string? ErrorUrl { get; set; }

    [JsonPropertyName("job_name")]
    public string? JobName { get; set; }

    [JsonPropertyName("output_url")]
    public string? OutputUrl { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("start_time")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public TriggeredWebJobStatusConstant? Status { get; set; }

    [JsonPropertyName("trigger")]
    public string? Trigger { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("web_job_id")]
    public string? WebJobId { get; set; }

    [JsonPropertyName("web_job_name")]
    public string? WebJobName { get; set; }
}
