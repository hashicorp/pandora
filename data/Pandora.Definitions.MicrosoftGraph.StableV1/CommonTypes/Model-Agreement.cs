// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AgreementModel
{
    [JsonPropertyName("acceptances")]
    public List<AgreementAcceptanceModel>? Acceptances { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("file")]
    public AgreementFileModel? File { get; set; }

    [JsonPropertyName("files")]
    public List<AgreementFileLocalizationModel>? Files { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isPerDeviceAcceptanceRequired")]
    public bool? IsPerDeviceAcceptanceRequired { get; set; }

    [JsonPropertyName("isViewingBeforeAcceptanceRequired")]
    public bool? IsViewingBeforeAcceptanceRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("termsExpiration")]
    public TermsExpirationModel? TermsExpiration { get; set; }

    [JsonPropertyName("userReacceptRequiredFrequency")]
    public string? UserReacceptRequiredFrequency { get; set; }
}
