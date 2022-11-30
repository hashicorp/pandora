using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.ContentKeyPolicies;

[ValueForType("#Microsoft.Media.ContentKeyPolicyRsaTokenKey")]
internal class ContentKeyPolicyRsaTokenKeyModel : ContentKeyPolicyRestrictionTokenKeyModel
{
    [JsonPropertyName("exponent")]
    [Required]
    public string Exponent { get; set; }

    [JsonPropertyName("modulus")]
    [Required]
    public string Modulus { get; set; }
}
