using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments
{

    internal class ExperimentExecutionActionTargetDetailsPropertiesModel
    {
        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("completedDateUtc")]
        public DateTime? CompletedDateUtc { get; set; }

        [JsonPropertyName("error")]
        public ExperimentExecutionActionTargetDetailsErrorModel? Error { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("failedDateUtc")]
        public DateTime? FailedDateUtc { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("target")]
        public string? Target { get; set; }
    }
}
