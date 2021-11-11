using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts
{

    internal class AlertPropertiesDetailsModel
    {
        [JsonPropertyName("amount")]
        public float? Amount { get; set; }

        [JsonPropertyName("contactEmails")]
        public List<string>? ContactEmails { get; set; }

        [JsonPropertyName("contactGroups")]
        public List<string>? ContactGroups { get; set; }

        [JsonPropertyName("contactRoles")]
        public List<string>? ContactRoles { get; set; }

        [JsonPropertyName("currentSpend")]
        public float? CurrentSpend { get; set; }

        [JsonPropertyName("meterFilter")]
        public List<object>? MeterFilter { get; set; }

        [JsonPropertyName("operator")]
        public AlertOperatorConstant? Operator { get; set; }

        [JsonPropertyName("overridingAlert")]
        public string? OverridingAlert { get; set; }

        [JsonPropertyName("periodStartDate")]
        public string? PeriodStartDate { get; set; }

        [JsonPropertyName("resourceFilter")]
        public List<object>? ResourceFilter { get; set; }

        [JsonPropertyName("resourceGroupFilter")]
        public List<object>? ResourceGroupFilter { get; set; }

        [JsonPropertyName("tagFilter")]
        public object? TagFilter { get; set; }

        [JsonPropertyName("threshold")]
        public float? Threshold { get; set; }

        [JsonPropertyName("timeGrainType")]
        public AlertTimeGrainTypeConstant? TimeGrainType { get; set; }

        [JsonPropertyName("triggeredBy")]
        public string? TriggeredBy { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }
    }
}
