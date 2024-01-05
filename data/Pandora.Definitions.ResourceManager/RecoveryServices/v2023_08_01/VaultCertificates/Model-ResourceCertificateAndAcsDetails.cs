using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_08_01.VaultCertificates;

[ValueForType("AccessControlService")]
internal class ResourceCertificateAndAcsDetailsModel : ResourceCertificateDetailsModel
{
    [JsonPropertyName("globalAcsHostName")]
    [Required]
    public string GlobalAcsHostName { get; set; }

    [JsonPropertyName("globalAcsNamespace")]
    [Required]
    public string GlobalAcsNamespace { get; set; }

    [JsonPropertyName("globalAcsRPRealm")]
    [Required]
    public string GlobalAcsRPRealm { get; set; }
}
