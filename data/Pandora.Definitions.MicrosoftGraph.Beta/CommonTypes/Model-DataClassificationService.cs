// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DataClassificationServiceModel
{
    [JsonPropertyName("classifyFileJobs")]
    public List<JobResponseBaseModel>? ClassifyFileJobs { get; set; }

    [JsonPropertyName("classifyTextJobs")]
    public List<JobResponseBaseModel>? ClassifyTextJobs { get; set; }

    [JsonPropertyName("evaluateDlpPoliciesJobs")]
    public List<JobResponseBaseModel>? EvaluateDlpPoliciesJobs { get; set; }

    [JsonPropertyName("evaluateLabelJobs")]
    public List<JobResponseBaseModel>? EvaluateLabelJobs { get; set; }

    [JsonPropertyName("exactMatchDataStores")]
    public List<ExactMatchDataStoreModel>? ExactMatchDataStores { get; set; }

    [JsonPropertyName("exactMatchUploadAgents")]
    public List<ExactMatchUploadAgentModel>? ExactMatchUploadAgents { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("jobs")]
    public List<JobResponseBaseModel>? Jobs { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sensitiveTypes")]
    public List<SensitiveTypeModel>? SensitiveTypes { get; set; }

    [JsonPropertyName("sensitivityLabels")]
    public List<SensitivityLabelModel>? SensitivityLabels { get; set; }
}
