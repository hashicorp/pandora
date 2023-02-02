using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2023_01_31.ManagedIdentities;


internal class FederatedIdentityCredentialPropertiesModel
{
    [JsonPropertyName("audiences")]
    [Required]
    public List<string> Audiences { get; set; }

    [JsonPropertyName("issuer")]
    [Required]
    public string Issuer { get; set; }

    [JsonPropertyName("subject")]
    [Required]
    public string Subject { get; set; }
}
