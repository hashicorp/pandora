// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MessageTraceModel
{
    [JsonPropertyName("destinationIPAddress")]
    public string? DestinationIPAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("receivedDateTime")]
    public DateTime? ReceivedDateTime { get; set; }

    [JsonPropertyName("recipients")]
    public List<MessageRecipientModel>? Recipients { get; set; }

    [JsonPropertyName("senderEmail")]
    public string? SenderEmail { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("sourceIPAddress")]
    public string? SourceIPAddress { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }
}
