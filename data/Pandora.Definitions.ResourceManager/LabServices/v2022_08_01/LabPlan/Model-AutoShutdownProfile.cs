using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.LabPlan;


internal class AutoShutdownProfileModel
{
    [JsonPropertyName("disconnectDelay")]
    public string? DisconnectDelay { get; set; }

    [JsonPropertyName("idleDelay")]
    public string? IdleDelay { get; set; }

    [JsonPropertyName("noConnectDelay")]
    public string? NoConnectDelay { get; set; }

    [JsonPropertyName("shutdownOnDisconnect")]
    public EnableStateConstant? ShutdownOnDisconnect { get; set; }

    [JsonPropertyName("shutdownOnIdle")]
    public ShutdownOnIdleModeConstant? ShutdownOnIdle { get; set; }

    [JsonPropertyName("shutdownWhenNotConnected")]
    public EnableStateConstant? ShutdownWhenNotConnected { get; set; }
}
