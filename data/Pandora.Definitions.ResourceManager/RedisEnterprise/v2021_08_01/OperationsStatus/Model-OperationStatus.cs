using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.OperationsStatus
{

    internal class OperationStatusModel
    {
        [JsonPropertyName("endTime")]
        public string? EndTime { get; set; }

        [JsonPropertyName("error")]
        public ErrorResponseModel? Error { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("startTime")]
        public string? StartTime { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}
