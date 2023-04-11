using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;


internal class JitNetworkAccessPortRuleModel
{
    [JsonPropertyName("allowedSourceAddressPrefix")]
    public string? AllowedSourceAddressPrefix { get; set; }

    [JsonPropertyName("allowedSourceAddressPrefixes")]
    public List<string>? AllowedSourceAddressPrefixes { get; set; }

    [JsonPropertyName("maxRequestAccessDuration")]
    [Required]
    public string MaxRequestAccessDuration { get; set; }

    [JsonPropertyName("number")]
    [Required]
    public int Number { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public ProtocolConstant Protocol { get; set; }
}
