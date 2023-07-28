using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.LabelingJob;

[ValueForType("Labeling")]
internal class LabelingJobModel : JobBaseModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dataConfiguration")]
    public LabelingDataConfigurationModel? DataConfiguration { get; set; }

    [JsonPropertyName("jobInstructions")]
    public LabelingJobInstructionsModel? JobInstructions { get; set; }

    [JsonPropertyName("labelCategories")]
    public Dictionary<string, LabelCategoryModel>? LabelCategories { get; set; }

    [JsonPropertyName("labelingJobMediaProperties")]
    public LabelingJobMediaPropertiesModel? LabelingJobMediaProperties { get; set; }

    [JsonPropertyName("mlAssistConfiguration")]
    public MLAssistConfigurationModel? MlAssistConfiguration { get; set; }

    [JsonPropertyName("progressMetrics")]
    public ProgressMetricsModel? ProgressMetrics { get; set; }

    [JsonPropertyName("projectId")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("provisioningState")]
    public JobProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("statusMessages")]
    public List<StatusMessageModel>? StatusMessages { get; set; }
}
