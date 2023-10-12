// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TicketInfoModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("ticketApproverIdentityId")]
    public string? TicketApproverIdentityId { get; set; }

    [JsonPropertyName("ticketNumber")]
    public string? TicketNumber { get; set; }

    [JsonPropertyName("ticketSubmitterIdentityId")]
    public string? TicketSubmitterIdentityId { get; set; }

    [JsonPropertyName("ticketSystem")]
    public string? TicketSystem { get; set; }
}
