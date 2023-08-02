// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedRoleSettingsModel
{
    [JsonPropertyName("approvalOnElevation")]
    public bool? ApprovalOnElevation { get; set; }

    [JsonPropertyName("approverIds")]
    public List<string>? ApproverIds { get; set; }

    [JsonPropertyName("elevationDuration")]
    public string? ElevationDuration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isMfaOnElevationConfigurable")]
    public bool? IsMfaOnElevationConfigurable { get; set; }

    [JsonPropertyName("lastGlobalAdmin")]
    public bool? LastGlobalAdmin { get; set; }

    [JsonPropertyName("maxElavationDuration")]
    public string? MaxElavationDuration { get; set; }

    [JsonPropertyName("mfaOnElevation")]
    public bool? MfaOnElevation { get; set; }

    [JsonPropertyName("minElevationDuration")]
    public string? MinElevationDuration { get; set; }

    [JsonPropertyName("notificationToUserOnElevation")]
    public bool? NotificationToUserOnElevation { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ticketingInfoOnElevation")]
    public bool? TicketingInfoOnElevation { get; set; }
}
