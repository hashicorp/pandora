using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;


internal class CertificateConfigurationModel
{
    [JsonPropertyName("certificate")]
    public CertificateInformationModel? Certificate { get; set; }

    [JsonPropertyName("certificatePassword")]
    public string? CertificatePassword { get; set; }

    [JsonPropertyName("encodedCertificate")]
    public string? EncodedCertificate { get; set; }

    [JsonPropertyName("storeName")]
    [Required]
    public StoreNameConstant StoreName { get; set; }
}
