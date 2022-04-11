using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;


internal class CustomDomainModel
{
    [JsonPropertyName("bindingType")]
    public BindingTypeConstant? BindingType { get; set; }

    [JsonPropertyName("certificateId")]
    [Required]
    public string CertificateId { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
