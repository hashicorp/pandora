// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AttendeeModel
{
    [JsonPropertyName("emailAddress")]
    public EmailAddressModel? EmailAddress { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("proposedNewTime")]
    public TimeSlotModel? ProposedNewTime { get; set; }

    [JsonPropertyName("status")]
    public ResponseStatusModel? Status { get; set; }

    [JsonPropertyName("type")]
    public AttendeeTypeConstant? Type { get; set; }
}
