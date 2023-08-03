// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Pkcs12CertificateInformationModel
{
    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("notAfter")]
    public long? NotAfter { get; set; }

    [JsonPropertyName("notBefore")]
    public long? NotBefore { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }
}
