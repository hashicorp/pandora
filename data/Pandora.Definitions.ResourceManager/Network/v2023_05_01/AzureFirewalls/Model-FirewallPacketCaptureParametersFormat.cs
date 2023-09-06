using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.AzureFirewalls;


internal class FirewallPacketCaptureParametersFormatModel
{
    [JsonPropertyName("durationInSeconds")]
    public int? DurationInSeconds { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("filters")]
    public List<AzureFirewallPacketCaptureRuleModel>? Filters { get; set; }

    [JsonPropertyName("flags")]
    public List<AzureFirewallPacketCaptureFlagsModel>? Flags { get; set; }

    [JsonPropertyName("numberOfPacketsToCapture")]
    public int? NumberOfPacketsToCapture { get; set; }

    [JsonPropertyName("protocol")]
    public AzureFirewallNetworkRuleProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("sasUrl")]
    public string? SasUrl { get; set; }
}
