// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallEndedEventMessageDetailModel
{
    [JsonPropertyName("callDuration")]
    public string? CallDuration { get; set; }

    [JsonPropertyName("callEventType")]
    public TeamworkCallEventTypeConstant? CallEventType { get; set; }

    [JsonPropertyName("callId")]
    public string? CallId { get; set; }

    [JsonPropertyName("callParticipants")]
    public List<CallParticipantInfoModel>? CallParticipants { get; set; }

    [JsonPropertyName("initiator")]
    public IdentitySetModel? Initiator { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
