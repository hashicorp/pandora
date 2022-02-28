using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.VMHHostList;


internal class VMResourcesModel
{
    [JsonPropertyName("vmResourceId")]
    public string? VmResourceId { get; set; }
}
