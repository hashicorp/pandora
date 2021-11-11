using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts
{

    internal class AlertPropertiesDefinitionModel
    {
        [JsonPropertyName("category")]
        public AlertCategoryConstant? Category { get; set; }

        [JsonPropertyName("criteria")]
        public AlertCriteriaConstant? Criteria { get; set; }

        [JsonPropertyName("type")]
        public AlertTypeConstant? Type { get; set; }
    }
}
