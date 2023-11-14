using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class TriggeredWebJobPropertiesModel
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("extra_info_url")]
    public string? ExtraInfoUrl { get; set; }

    [JsonPropertyName("history_url")]
    public string? HistoryUrl { get; set; }

    [JsonPropertyName("latest_run")]
    public TriggeredJobRunModel? LatestRun { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public string? PublicNetworkAccess { get; set; }

    [JsonPropertyName("run_command")]
    public string? RunCommand { get; set; }

    [JsonPropertyName("scheduler_logs_url")]
    public string? SchedulerLogsUrl { get; set; }

    [JsonPropertyName("settings")]
    public Dictionary<string, object>? Settings { get; set; }

    [JsonPropertyName("storageAccountRequired")]
    public bool? StorageAccountRequired { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("using_sdk")]
    public bool? UsingSdk { get; set; }

    [JsonPropertyName("web_job_type")]
    public WebJobTypeConstant? WebJobType { get; set; }
}
