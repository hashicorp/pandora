// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VppTokenLicenseSummaryModel
{
    [JsonPropertyName("appleId")]
    public string? AppleId { get; set; }

    [JsonPropertyName("availableLicenseCount")]
    public int? AvailableLicenseCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organizationName")]
    public string? OrganizationName { get; set; }

    [JsonPropertyName("usedLicenseCount")]
    public int? UsedLicenseCount { get; set; }

    [JsonPropertyName("vppTokenId")]
    public string? VppTokenId { get; set; }
}
