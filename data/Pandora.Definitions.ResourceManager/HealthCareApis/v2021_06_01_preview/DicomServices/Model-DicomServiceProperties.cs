using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.DicomServices;


internal class DicomServicePropertiesModel
{
    [JsonPropertyName("authenticationConfiguration")]
    public DicomServiceAuthenticationConfigurationModel? AuthenticationConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serviceUrl")]
    public string? ServiceUrl { get; set; }
}
