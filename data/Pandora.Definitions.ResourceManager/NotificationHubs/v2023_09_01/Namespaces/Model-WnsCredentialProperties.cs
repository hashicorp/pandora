using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;


internal class WnsCredentialPropertiesModel
{
    [JsonPropertyName("certificateKey")]
    public string? CertificateKey { get; set; }

    [JsonPropertyName("packageSid")]
    public string? PackageSid { get; set; }

    [JsonPropertyName("secretKey")]
    public string? SecretKey { get; set; }

    [JsonPropertyName("windowsLiveEndpoint")]
    public string? WindowsLiveEndpoint { get; set; }

    [JsonPropertyName("wnsCertificate")]
    public string? WnsCertificate { get; set; }
}
