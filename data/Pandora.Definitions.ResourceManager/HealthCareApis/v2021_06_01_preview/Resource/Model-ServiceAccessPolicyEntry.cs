using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.Resource;


internal class ServiceAccessPolicyEntryModel
{
    [JsonPropertyName("objectId")]
    [Required]
    public string ObjectId { get; set; }
}
