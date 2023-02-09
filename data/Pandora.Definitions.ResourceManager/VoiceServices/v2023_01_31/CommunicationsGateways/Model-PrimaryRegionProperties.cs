using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_01_31.CommunicationsGateways;


internal class PrimaryRegionPropertiesModel
{
    [JsonPropertyName("allowedMediaSourceAddressPrefixes")]
    public List<string>? AllowedMediaSourceAddressPrefixes { get; set; }

    [JsonPropertyName("allowedSignalingSourceAddressPrefixes")]
    public List<string>? AllowedSignalingSourceAddressPrefixes { get; set; }

    [JsonPropertyName("esrpAddresses")]
    public List<string>? EsrpAddresses { get; set; }

    [JsonPropertyName("operatorAddresses")]
    [Required]
    public List<string> OperatorAddresses { get; set; }
}
