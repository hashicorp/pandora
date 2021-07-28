using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{

    internal class ErrorDetail
    {
        [JsonPropertyName("additionalInfo")]
        public List<ErrorAdditionalInfo>? AdditionalInfo { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("details")]
        public List<ErrorDetail>? Details { get; set; }

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
