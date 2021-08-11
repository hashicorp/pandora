using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.AnalysisServices
{

    internal class SkuEnumerationForNewResourceResultModel
    {
        [JsonPropertyName("value")]
        public List<ResourceSkuModel>? Value { get; set; }
    }
}
