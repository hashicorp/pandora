// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NotificationModel
{
    [JsonPropertyName("displayTimeToLive")]
    public int? DisplayTimeToLive { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("groupName")]
    public string? GroupName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payload")]
    public PayloadTypesModel? Payload { get; set; }

    [JsonPropertyName("priority")]
    public PriorityConstant? Priority { get; set; }

    [JsonPropertyName("targetHostName")]
    public string? TargetHostName { get; set; }

    [JsonPropertyName("targetPolicy")]
    public TargetPolicyEndpointsModel? TargetPolicy { get; set; }
}
