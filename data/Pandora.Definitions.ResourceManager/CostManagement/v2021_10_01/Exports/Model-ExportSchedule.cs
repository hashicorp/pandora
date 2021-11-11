using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports
{

    internal class ExportScheduleModel
    {
        [JsonPropertyName("recurrence")]
        public RecurrenceTypeConstant? Recurrence { get; set; }

        [JsonPropertyName("recurrencePeriod")]
        public ExportRecurrencePeriodModel? RecurrencePeriod { get; set; }

        [JsonPropertyName("status")]
        public StatusTypeConstant? Status { get; set; }
    }
}
