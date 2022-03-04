using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.DicomServices;


internal class ResourceTagsModel
{
    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
