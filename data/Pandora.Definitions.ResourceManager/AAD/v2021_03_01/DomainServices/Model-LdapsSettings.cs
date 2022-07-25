using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2021_03_01.DomainServices;


internal class LdapsSettingsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("certificateNotAfter")]
    public DateTime? CertificateNotAfter { get; set; }

    [JsonPropertyName("certificateThumbprint")]
    public string? CertificateThumbprint { get; set; }

    [JsonPropertyName("externalAccess")]
    public ExternalAccessConstant? ExternalAccess { get; set; }

    [JsonPropertyName("ldaps")]
    public LdapsConstant? Ldaps { get; set; }

    [JsonPropertyName("pfxCertificate")]
    public string? PfxCertificate { get; set; }

    [JsonPropertyName("pfxCertificatePassword")]
    public string? PfxCertificatePassword { get; set; }

    [JsonPropertyName("publicCertificate")]
    public string? PublicCertificate { get; set; }
}
