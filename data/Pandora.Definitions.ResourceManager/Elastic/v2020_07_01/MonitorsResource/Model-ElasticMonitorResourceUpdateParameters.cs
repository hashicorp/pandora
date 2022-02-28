using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;


internal class ElasticMonitorResourceUpdateParametersModel
{
    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
