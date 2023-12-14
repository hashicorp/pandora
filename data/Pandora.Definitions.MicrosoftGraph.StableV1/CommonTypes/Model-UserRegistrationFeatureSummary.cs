// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserRegistrationFeatureSummaryModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalUserCount")]
    public int? TotalUserCount { get; set; }

    [JsonPropertyName("userRegistrationFeatureCounts")]
    public List<UserRegistrationFeatureCountModel>? UserRegistrationFeatureCounts { get; set; }

    [JsonPropertyName("userRoles")]
    public UserRegistrationFeatureSummaryUserRolesConstant? UserRoles { get; set; }

    [JsonPropertyName("userTypes")]
    public UserRegistrationFeatureSummaryUserTypesConstant? UserTypes { get; set; }
}
