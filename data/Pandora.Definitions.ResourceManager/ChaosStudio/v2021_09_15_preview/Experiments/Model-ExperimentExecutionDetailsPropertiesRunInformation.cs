using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;


internal class ExperimentExecutionDetailsPropertiesRunInformationModel
{
    [JsonPropertyName("steps")]
    public List<StepStatusModel>? Steps { get; set; }
}
