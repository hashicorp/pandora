using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class ClientCertificateCommonNameModel
{
    [JsonPropertyName("certificateCommonName")]
    [Required]
    public string CertificateCommonName { get; set; }

    [JsonPropertyName("certificateIssuerThumbprint")]
    [Required]
    public string CertificateIssuerThumbprint { get; set; }

    [JsonPropertyName("isAdmin")]
    [Required]
    public bool IsAdmin { get; set; }
}
