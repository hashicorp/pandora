using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_06_01.FhirServices;


internal class ResourceVersionPolicyConfigurationModel
{
    [JsonPropertyName("default")]
    public FhirResourceVersionPolicyConstant? Default { get; set; }

    [JsonPropertyName("resourceTypeOverrides")]
    public Dictionary<string, FhirResourceVersionPolicyConstant>? ResourceTypeOverrides { get; set; }
}
