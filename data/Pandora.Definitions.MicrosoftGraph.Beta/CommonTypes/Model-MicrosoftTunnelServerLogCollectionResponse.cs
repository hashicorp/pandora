// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MicrosoftTunnelServerLogCollectionResponseModel
{
    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("expiryDateTime")]
    public DateTime? ExpiryDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestDateTime")]
    public DateTime? RequestDateTime { get; set; }

    [JsonPropertyName("serverId")]
    public string? ServerId { get; set; }

    [JsonPropertyName("sizeInBytes")]
    public long? SizeInBytes { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public MicrosoftTunnelLogCollectionStatusConstant? Status { get; set; }
}
