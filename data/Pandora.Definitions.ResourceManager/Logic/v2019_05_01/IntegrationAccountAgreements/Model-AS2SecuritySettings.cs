using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AS2SecuritySettingsModel
{
    [JsonPropertyName("enableNRRForInboundDecodedMessages")]
    [Required]
    public bool EnableNRRForInboundDecodedMessages { get; set; }

    [JsonPropertyName("enableNRRForInboundEncodedMessages")]
    [Required]
    public bool EnableNRRForInboundEncodedMessages { get; set; }

    [JsonPropertyName("enableNRRForInboundMDN")]
    [Required]
    public bool EnableNRRForInboundMDN { get; set; }

    [JsonPropertyName("enableNRRForOutboundDecodedMessages")]
    [Required]
    public bool EnableNRRForOutboundDecodedMessages { get; set; }

    [JsonPropertyName("enableNRRForOutboundEncodedMessages")]
    [Required]
    public bool EnableNRRForOutboundEncodedMessages { get; set; }

    [JsonPropertyName("enableNRRForOutboundMDN")]
    [Required]
    public bool EnableNRRForOutboundMDN { get; set; }

    [JsonPropertyName("encryptionCertificateName")]
    public string? EncryptionCertificateName { get; set; }

    [JsonPropertyName("overrideGroupSigningCertificate")]
    [Required]
    public bool OverrideGroupSigningCertificate { get; set; }

    [JsonPropertyName("sha2AlgorithmFormat")]
    public string? Sha2AlgorithmFormat { get; set; }

    [JsonPropertyName("signingCertificateName")]
    public string? SigningCertificateName { get; set; }
}
