using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchDeployment;


internal class BatchDeploymentModel
{
    [JsonPropertyName("codeConfiguration")]
    public CodeConfigurationModel? CodeConfiguration { get; set; }

    [JsonPropertyName("compute")]
    public string? Compute { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("errorThreshold")]
    public int? ErrorThreshold { get; set; }

    [JsonPropertyName("loggingLevel")]
    public BatchLoggingLevelConstant? LoggingLevel { get; set; }

    [JsonPropertyName("maxConcurrencyPerInstance")]
    public int? MaxConcurrencyPerInstance { get; set; }

    [JsonPropertyName("miniBatchSize")]
    public int? MiniBatchSize { get; set; }

    [JsonPropertyName("model")]
    public AssetReferenceBaseModel? Model { get; set; }

    [JsonPropertyName("outputAction")]
    public BatchOutputActionConstant? OutputAction { get; set; }

    [JsonPropertyName("outputFileName")]
    public string? OutputFileName { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("provisioningState")]
    public DeploymentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resources")]
    public ResourceConfigurationModel? Resources { get; set; }

    [JsonPropertyName("retrySettings")]
    public BatchRetrySettingsModel? RetrySettings { get; set; }
}
