using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.IotConnectors;


internal class IotFhirDestinationPropertiesModel
{
    [JsonPropertyName("fhirMapping")]
    [Required]
    public IotMappingPropertiesModel FhirMapping { get; set; }

    [JsonPropertyName("fhirServiceResourceId")]
    [Required]
    public string FhirServiceResourceId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceIdentityResolutionType")]
    [Required]
    public IotIdentityResolutionTypeConstant ResourceIdentityResolutionType { get; set; }
}
