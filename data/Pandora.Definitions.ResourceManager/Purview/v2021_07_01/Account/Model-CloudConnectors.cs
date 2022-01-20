using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account;


internal class CloudConnectorsModel
{
    [JsonPropertyName("awsExternalId")]
    public string? AwsExternalId { get; set; }
}
