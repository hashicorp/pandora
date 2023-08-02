// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MessageSecurityStateModel
{
    [JsonPropertyName("connectingIP")]
    public string? ConnectingIP { get; set; }

    [JsonPropertyName("deliveryAction")]
    public string? DeliveryAction { get; set; }

    [JsonPropertyName("deliveryLocation")]
    public string? DeliveryLocation { get; set; }

    [JsonPropertyName("directionality")]
    public string? Directionality { get; set; }

    [JsonPropertyName("internetMessageId")]
    public string? InternetMessageId { get; set; }

    [JsonPropertyName("messageFingerprint")]
    public string? MessageFingerprint { get; set; }

    [JsonPropertyName("messageReceivedDateTime")]
    public DateTime? MessageReceivedDateTime { get; set; }

    [JsonPropertyName("messageSubject")]
    public string? MessageSubject { get; set; }

    [JsonPropertyName("networkMessageId")]
    public string? NetworkMessageId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
