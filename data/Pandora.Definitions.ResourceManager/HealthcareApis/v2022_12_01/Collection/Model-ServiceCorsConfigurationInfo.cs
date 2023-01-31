using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_12_01.Collection;


internal class ServiceCorsConfigurationInfoModel
{
    [JsonPropertyName("allowCredentials")]
    public bool? AllowCredentials { get; set; }

    [JsonPropertyName("headers")]
    public List<string>? Headers { get; set; }

    [JsonPropertyName("maxAge")]
    public int? MaxAge { get; set; }

    [JsonPropertyName("methods")]
    public List<string>? Methods { get; set; }

    [JsonPropertyName("origins")]
    public List<string>? Origins { get; set; }
}
