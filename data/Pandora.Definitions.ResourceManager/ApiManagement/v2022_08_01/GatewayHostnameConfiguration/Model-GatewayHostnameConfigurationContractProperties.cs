using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.GatewayHostnameConfiguration;


internal class GatewayHostnameConfigurationContractPropertiesModel
{
    [JsonPropertyName("certificateId")]
    public string? CertificateId { get; set; }

    [JsonPropertyName("http2Enabled")]
    public bool? HTTP2Enabled { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("negotiateClientCertificate")]
    public bool? NegotiateClientCertificate { get; set; }

    [JsonPropertyName("tls10Enabled")]
    public bool? Tls10Enabled { get; set; }

    [JsonPropertyName("tls11Enabled")]
    public bool? Tls11Enabled { get; set; }
}
