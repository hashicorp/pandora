// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserTrainingEventInfoModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("latestTrainingStatus")]
    public TrainingStatusConstant? LatestTrainingStatus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("trainingAssignedProperties")]
    public UserTrainingContentEventInfoModel? TrainingAssignedProperties { get; set; }

    [JsonPropertyName("trainingCompletedProperties")]
    public UserTrainingContentEventInfoModel? TrainingCompletedProperties { get; set; }

    [JsonPropertyName("trainingUpdatedProperties")]
    public UserTrainingContentEventInfoModel? TrainingUpdatedProperties { get; set; }
}
