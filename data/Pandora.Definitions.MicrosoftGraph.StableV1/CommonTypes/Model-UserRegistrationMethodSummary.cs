// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserRegistrationMethodSummaryModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalUserCount")]
    public int? TotalUserCount { get; set; }

    [JsonPropertyName("userRegistrationMethodCounts")]
    public List<UserRegistrationMethodCountModel>? UserRegistrationMethodCounts { get; set; }

    [JsonPropertyName("userRoles")]
    public UserRegistrationMethodSummaryUserRolesConstant? UserRoles { get; set; }

    [JsonPropertyName("userTypes")]
    public UserRegistrationMethodSummaryUserTypesConstant? UserTypes { get; set; }
}
