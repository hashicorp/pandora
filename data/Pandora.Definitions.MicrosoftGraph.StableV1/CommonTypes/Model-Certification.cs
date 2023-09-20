// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CertificationModel
{
    [JsonPropertyName("certificationDetailsUrl")]
    public string? CertificationDetailsUrl { get; set; }

    [JsonPropertyName("certificationExpirationDateTime")]
    public DateTime? CertificationExpirationDateTime { get; set; }

    [JsonPropertyName("isCertifiedByMicrosoft")]
    public bool? IsCertifiedByMicrosoft { get; set; }

    [JsonPropertyName("isPublisherAttested")]
    public bool? IsPublisherAttested { get; set; }

    [JsonPropertyName("lastCertificationDateTime")]
    public DateTime? LastCertificationDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
