using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimes;


internal class IntegrationRuntimeNodeMonitoringDataModel
{
    [JsonPropertyName("availableMemoryInMB")]
    public int? AvailableMemoryInMB { get; set; }

    [JsonPropertyName("concurrentJobsLimit")]
    public int? ConcurrentJobsLimit { get; set; }

    [JsonPropertyName("concurrentJobsRunning")]
    public int? ConcurrentJobsRunning { get; set; }

    [JsonPropertyName("cpuUtilization")]
    public int? CpuUtilization { get; set; }

    [JsonPropertyName("maxConcurrentJobs")]
    public int? MaxConcurrentJobs { get; set; }

    [JsonPropertyName("nodeName")]
    public string? NodeName { get; set; }

    [JsonPropertyName("receivedBytes")]
    public float? ReceivedBytes { get; set; }

    [JsonPropertyName("sentBytes")]
    public float? SentBytes { get; set; }
}
