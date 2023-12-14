using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_09_01.CommunicationsGateways;


internal class ApiBridgePropertiesModel
{
    [JsonPropertyName("allowedAddressPrefixes")]
    public List<string>? AllowedAddressPrefixes { get; set; }

    [JsonPropertyName("configureApiBridge")]
    public ApiBridgeActivationStateConstant? ConfigureApiBridge { get; set; }

    [JsonPropertyName("endpointFqdns")]
    public List<string>? EndpointFqdns { get; set; }
}
