// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserRegistrationMethodSummaryModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("totalUserCount")]
    public long? TotalUserCount { get; set; }

    [JsonPropertyName("userRegistrationMethodCounts")]
    public List<UserRegistrationMethodCountModel>? UserRegistrationMethodCounts { get; set; }

    [JsonPropertyName("userRoles")]
    public IncludedUserRolesConstant? UserRoles { get; set; }

    [JsonPropertyName("userTypes")]
    public IncludedUserTypesConstant? UserTypes { get; set; }
}
