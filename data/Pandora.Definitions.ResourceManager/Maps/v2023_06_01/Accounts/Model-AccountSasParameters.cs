using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2023_06_01.Accounts;


internal class AccountSasParametersModel
{
    [JsonPropertyName("expiry")]
    [Required]
    public string Expiry { get; set; }

    [JsonPropertyName("maxRatePerSecond")]
    [Required]
    public int MaxRatePerSecond { get; set; }

    [JsonPropertyName("principalId")]
    [Required]
    public string PrincipalId { get; set; }

    [JsonPropertyName("regions")]
    public List<string>? Regions { get; set; }

    [JsonPropertyName("signingKey")]
    [Required]
    public SigningKeyConstant SigningKey { get; set; }

    [JsonPropertyName("start")]
    [Required]
    public string Start { get; set; }
}
