using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.Certificate;


internal class CertificateCreateOrUpdatePropertiesModel
{
    [JsonPropertyName("data")]
    [Required]
    public string Data { get; set; }

    [JsonPropertyName("format")]
    public CertificateFormatConstant? Format { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("thumbprintAlgorithm")]
    public string? ThumbprintAlgorithm { get; set; }
}
