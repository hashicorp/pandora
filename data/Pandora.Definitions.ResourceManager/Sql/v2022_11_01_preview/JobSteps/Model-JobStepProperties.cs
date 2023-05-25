using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.JobSteps;


internal class JobStepPropertiesModel
{
    [JsonPropertyName("action")]
    [Required]
    public JobStepActionModel Action { get; set; }

    [JsonPropertyName("credential")]
    [Required]
    public string Credential { get; set; }

    [JsonPropertyName("executionOptions")]
    public JobStepExecutionOptionsModel? ExecutionOptions { get; set; }

    [JsonPropertyName("output")]
    public JobStepOutputModel? Output { get; set; }

    [JsonPropertyName("stepId")]
    public int? StepId { get; set; }

    [JsonPropertyName("targetGroup")]
    [Required]
    public string TargetGroup { get; set; }
}
