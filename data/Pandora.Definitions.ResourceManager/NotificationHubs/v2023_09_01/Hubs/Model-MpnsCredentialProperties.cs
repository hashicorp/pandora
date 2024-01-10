using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Hubs;


internal class MpnsCredentialPropertiesModel
{
    [JsonPropertyName("certificateKey")]
    [Required]
    public string CertificateKey { get; set; }

    [JsonPropertyName("mpnsCertificate")]
    [Required]
    public string MpnsCertificate { get; set; }

    [JsonPropertyName("thumbprint")]
    [Required]
    public string Thumbprint { get; set; }
}
