using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;


internal class AzureMachineLearningServiceFunctionBindingPropertiesModel
{
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    [JsonPropertyName("batchSize")]
    public int? BatchSize { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("inputRequestName")]
    public string? InputRequestName { get; set; }

    [JsonPropertyName("inputs")]
    public List<AzureMachineLearningServiceInputColumnModel>? Inputs { get; set; }

    [JsonPropertyName("numberOfParallelRequests")]
    public int? NumberOfParallelRequests { get; set; }

    [JsonPropertyName("outputResponseName")]
    public string? OutputResponseName { get; set; }

    [JsonPropertyName("outputs")]
    public List<AzureMachineLearningServiceOutputColumnModel>? Outputs { get; set; }
}
