using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;


internal class AzureSqlDatabaseDataSourcePropertiesModel
{
    [JsonPropertyName("authenticationMode")]
    public AuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("database")]
    public string? Database { get; set; }

    [JsonPropertyName("maxBatchCount")]
    public float? MaxBatchCount { get; set; }

    [JsonPropertyName("maxWriterCount")]
    public float? MaxWriterCount { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("server")]
    public string? Server { get; set; }

    [JsonPropertyName("table")]
    public string? Table { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }
}
