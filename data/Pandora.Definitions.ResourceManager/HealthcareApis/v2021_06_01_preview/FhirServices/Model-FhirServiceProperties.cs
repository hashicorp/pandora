using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2021_06_01_preview.FhirServices;


internal class FhirServicePropertiesModel
{
    [JsonPropertyName("accessPolicies")]
    public List<FhirServiceAccessPolicyEntryModel>? AccessPolicies { get; set; }

    [JsonPropertyName("acrConfiguration")]
    public FhirServiceAcrConfigurationModel? AcrConfiguration { get; set; }

    [JsonPropertyName("authenticationConfiguration")]
    public FhirServiceAuthenticationConfigurationModel? AuthenticationConfiguration { get; set; }

    [JsonPropertyName("corsConfiguration")]
    public FhirServiceCorsConfigurationModel? CorsConfiguration { get; set; }

    [JsonPropertyName("exportConfiguration")]
    public FhirServiceExportConfigurationModel? ExportConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
