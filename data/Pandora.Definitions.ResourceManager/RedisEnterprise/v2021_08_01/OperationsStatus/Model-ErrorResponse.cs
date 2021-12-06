using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.OperationsStatus
{

    internal class ErrorResponseModel
    {
        [JsonPropertyName("error")]
        public ErrorDetailModel? Error { get; set; }
    }
}
