using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_11_01.Collection;


internal class ServiceAuthenticationConfigurationInfoModel
{
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    [JsonPropertyName("authority")]
    public string? Authority { get; set; }

    [JsonPropertyName("smartProxyEnabled")]
    public bool? SmartProxyEnabled { get; set; }
}
