// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidEnrollmentCompanyCodeModel
{
    [JsonPropertyName("enrollmentToken")]
    public string? EnrollmentToken { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("qrCodeContent")]
    public string? QrCodeContent { get; set; }

    [JsonPropertyName("qrCodeImage")]
    public MimeContentModel? QrCodeImage { get; set; }
}
