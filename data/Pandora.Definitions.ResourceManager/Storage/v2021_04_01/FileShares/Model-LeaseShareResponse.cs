using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;


internal class LeaseShareResponseModel
{
    [JsonPropertyName("leaseId")]
    public string? LeaseId { get; set; }

    [JsonPropertyName("leaseTimeSeconds")]
    public string? LeaseTimeSeconds { get; set; }
}
