using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.JobSteps;


internal class JobStepExecutionOptionsModel
{
    [JsonPropertyName("initialRetryIntervalSeconds")]
    public int? InitialRetryIntervalSeconds { get; set; }

    [JsonPropertyName("maximumRetryIntervalSeconds")]
    public int? MaximumRetryIntervalSeconds { get; set; }

    [JsonPropertyName("retryAttempts")]
    public int? RetryAttempts { get; set; }

    [JsonPropertyName("retryIntervalBackoffMultiplier")]
    public float? RetryIntervalBackoffMultiplier { get; set; }

    [JsonPropertyName("timeoutSeconds")]
    public int? TimeoutSeconds { get; set; }
}
