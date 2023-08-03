// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserRegistrationDetailsModel
{
    [JsonPropertyName("defaultMfaMethod")]
    public DefaultMfaMethodTypeConstant? DefaultMfaMethod { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAdmin")]
    public bool? IsAdmin { get; set; }

    [JsonPropertyName("isMfaCapable")]
    public bool? IsMfaCapable { get; set; }

    [JsonPropertyName("isMfaRegistered")]
    public bool? IsMfaRegistered { get; set; }

    [JsonPropertyName("isPasswordlessCapable")]
    public bool? IsPasswordlessCapable { get; set; }

    [JsonPropertyName("isSsprCapable")]
    public bool? IsSsprCapable { get; set; }

    [JsonPropertyName("isSsprEnabled")]
    public bool? IsSsprEnabled { get; set; }

    [JsonPropertyName("isSsprRegistered")]
    public bool? IsSsprRegistered { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("methodsRegistered")]
    public List<string>? MethodsRegistered { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("userType")]
    public SignInUserTypeConstant? UserType { get; set; }
}
