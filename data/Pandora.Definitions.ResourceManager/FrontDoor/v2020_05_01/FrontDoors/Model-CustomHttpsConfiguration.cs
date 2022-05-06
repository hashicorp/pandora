using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;


internal class CustomHttpsConfigurationModel
{
    [JsonPropertyName("certificateSource")]
    [Required]
    public FrontDoorCertificateSourceConstant CertificateSource { get; set; }

    [JsonPropertyName("frontDoorCertificateSourceParameters")]
    public FrontDoorCertificateSourceParametersModel? FrontDoorCertificateSourceParameters { get; set; }

    [JsonPropertyName("keyVaultCertificateSourceParameters")]
    public KeyVaultCertificateSourceParametersModel? KeyVaultCertificateSourceParameters { get; set; }

    [JsonPropertyName("minimumTlsVersion")]
    [Required]
    public MinimumTLSVersionConstant MinimumTlsVersion { get; set; }

    [JsonPropertyName("protocolType")]
    [Required]
    public FrontDoorTlsProtocolTypeConstant ProtocolType { get; set; }
}
