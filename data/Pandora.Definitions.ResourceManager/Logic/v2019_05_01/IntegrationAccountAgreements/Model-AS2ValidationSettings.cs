using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AS2ValidationSettingsModel
{
    [JsonPropertyName("checkCertificateRevocationListOnReceive")]
    [Required]
    public bool CheckCertificateRevocationListOnReceive { get; set; }

    [JsonPropertyName("checkCertificateRevocationListOnSend")]
    [Required]
    public bool CheckCertificateRevocationListOnSend { get; set; }

    [JsonPropertyName("checkDuplicateMessage")]
    [Required]
    public bool CheckDuplicateMessage { get; set; }

    [JsonPropertyName("compressMessage")]
    [Required]
    public bool CompressMessage { get; set; }

    [JsonPropertyName("encryptMessage")]
    [Required]
    public bool EncryptMessage { get; set; }

    [JsonPropertyName("encryptionAlgorithm")]
    [Required]
    public EncryptionAlgorithmConstant EncryptionAlgorithm { get; set; }

    [JsonPropertyName("interchangeDuplicatesValidityDays")]
    [Required]
    public int InterchangeDuplicatesValidityDays { get; set; }

    [JsonPropertyName("overrideMessageProperties")]
    [Required]
    public bool OverrideMessageProperties { get; set; }

    [JsonPropertyName("signMessage")]
    [Required]
    public bool SignMessage { get; set; }

    [JsonPropertyName("signingAlgorithm")]
    public SigningAlgorithmConstant? SigningAlgorithm { get; set; }
}
