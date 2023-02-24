using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectors;


internal class CodelessConnectorPollingRequestPropertiesModel
{
    [JsonPropertyName("apiEndpoint")]
    [Required]
    public string ApiEndpoint { get; set; }

    [JsonPropertyName("endTimeAttributeName")]
    public string? EndTimeAttributeName { get; set; }

    [JsonPropertyName("httpMethod")]
    [Required]
    public string HTTPMethod { get; set; }

    [JsonPropertyName("headers")]
    public object? Headers { get; set; }

    [JsonPropertyName("queryParameters")]
    public object? QueryParameters { get; set; }

    [JsonPropertyName("queryParametersTemplate")]
    public string? QueryParametersTemplate { get; set; }

    [JsonPropertyName("queryTimeFormat")]
    [Required]
    public string QueryTimeFormat { get; set; }

    [JsonPropertyName("queryWindowInMin")]
    [Required]
    public int QueryWindowInMin { get; set; }

    [JsonPropertyName("rateLimitQps")]
    public int? RateLimitQps { get; set; }

    [JsonPropertyName("retryCount")]
    public int? RetryCount { get; set; }

    [JsonPropertyName("startTimeAttributeName")]
    public string? StartTimeAttributeName { get; set; }

    [JsonPropertyName("timeoutInSeconds")]
    public int? TimeoutInSeconds { get; set; }
}
