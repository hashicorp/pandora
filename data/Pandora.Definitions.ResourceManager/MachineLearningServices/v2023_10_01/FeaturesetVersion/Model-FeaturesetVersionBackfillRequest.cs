using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.FeaturesetVersion;


internal class FeaturesetVersionBackfillRequestModel
{
    [JsonPropertyName("dataAvailabilityStatus")]
    public List<DataAvailabilityStatusConstant>? DataAvailabilityStatus { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("featureWindow")]
    public FeatureWindowModel? FeatureWindow { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("resource")]
    public MaterializationComputeResourceModel? Resource { get; set; }

    [JsonPropertyName("sparkConfiguration")]
    public Dictionary<string, string>? SparkConfiguration { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
