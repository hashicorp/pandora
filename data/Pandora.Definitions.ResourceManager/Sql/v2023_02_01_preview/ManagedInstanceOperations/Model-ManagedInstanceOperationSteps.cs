using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstanceOperations;


internal class ManagedInstanceOperationStepsModel
{
    [JsonPropertyName("currentStep")]
    public int? CurrentStep { get; set; }

    [JsonPropertyName("stepsList")]
    public List<UpsertManagedServerOperationStepWithEstimatesAndDurationModel>? StepsList { get; set; }

    [JsonPropertyName("totalSteps")]
    public string? TotalSteps { get; set; }
}
