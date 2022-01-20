using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds;


internal class EndpointsModel
{
    [JsonPropertyName("hcxCloudManager")]
    public string? HcxCloudManager { get; set; }

    [JsonPropertyName("nsxtManager")]
    public string? NsxtManager { get; set; }

    [JsonPropertyName("vcsa")]
    public string? Vcsa { get; set; }
}
