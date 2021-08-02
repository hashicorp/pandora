using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{

    internal class ErrorDetailModel
    {
        [JsonPropertyName("additionalInfo")]
        public List<ErrorAdditionalInfoModel>? AdditionalInfo { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("details")]
        public List<ErrorDetailModel>? Details { get; set; }

        [JsonPropertyName("httpStatusCode")]
        public int? HttpStatusCode { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("subCode")]
        public int? SubCode { get; set; }

        [JsonPropertyName("target")]
        public string? Target { get; set; }

        [JsonPropertyName("timeStamp")]
        public string? TimeStamp { get; set; }
    }
}
