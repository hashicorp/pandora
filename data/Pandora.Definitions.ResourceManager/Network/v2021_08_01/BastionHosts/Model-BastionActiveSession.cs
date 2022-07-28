using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.BastionHosts;


internal class BastionActiveSessionModel
{
    [JsonPropertyName("protocol")]
    public BastionConnectProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("sessionDurationInMins")]
    public float? SessionDurationInMins { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    [JsonPropertyName("startTime")]
    public object? StartTime { get; set; }

    [JsonPropertyName("targetHostName")]
    public string? TargetHostName { get; set; }

    [JsonPropertyName("targetIpAddress")]
    public string? TargetIPAddress { get; set; }

    [JsonPropertyName("targetResourceGroup")]
    public string? TargetResourceGroup { get; set; }

    [JsonPropertyName("targetResourceId")]
    public string? TargetResourceId { get; set; }

    [JsonPropertyName("targetSubscriptionId")]
    public string? TargetSubscriptionId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
