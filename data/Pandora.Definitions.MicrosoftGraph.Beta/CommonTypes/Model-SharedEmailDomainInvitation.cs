// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SharedEmailDomainInvitationModel
{
    [JsonPropertyName("expiryTime")]
    public DateTime? ExpiryTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("invitationDomain")]
    public string? InvitationDomain { get; set; }

    [JsonPropertyName("invitationStatus")]
    public string? InvitationStatus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
