using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Certificate;


internal class CertificatePropertiesModel
{
    [JsonPropertyName("deleteCertificateError")]
    public DeleteCertificateErrorModel? DeleteCertificateError { get; set; }

    [JsonPropertyName("format")]
    public CertificateFormatConstant? Format { get; set; }

    [JsonPropertyName("previousProvisioningState")]
    public CertificateProvisioningStateConstant? PreviousProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("previousProvisioningStateTransitionTime")]
    public DateTime? PreviousProvisioningStateTransitionTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public CertificateProvisioningStateConstant? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("provisioningStateTransitionTime")]
    public DateTime? ProvisioningStateTransitionTime { get; set; }

    [JsonPropertyName("publicData")]
    public string? PublicData { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("thumbprintAlgorithm")]
    public string? ThumbprintAlgorithm { get; set; }
}
