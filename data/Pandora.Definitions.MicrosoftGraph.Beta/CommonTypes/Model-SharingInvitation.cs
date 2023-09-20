// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SharingInvitationModel
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("invitedBy")]
    public IdentitySetModel? InvitedBy { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("redeemedBy")]
    public string? RedeemedBy { get; set; }

    [JsonPropertyName("signInRequired")]
    public bool? SignInRequired { get; set; }
}
