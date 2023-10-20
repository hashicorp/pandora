using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.Firewalls;


internal class LogSettingsModel
{
    [JsonPropertyName("applicationInsights")]
    public ApplicationInsightsModel? ApplicationInsights { get; set; }

    [JsonPropertyName("commonDestination")]
    public LogDestinationModel? CommonDestination { get; set; }

    [JsonPropertyName("decryptLogDestination")]
    public LogDestinationModel? DecryptLogDestination { get; set; }

    [JsonPropertyName("logOption")]
    public LogOptionConstant? LogOption { get; set; }

    [JsonPropertyName("logType")]
    public LogTypeConstant? LogType { get; set; }

    [JsonPropertyName("threatLogDestination")]
    public LogDestinationModel? ThreatLogDestination { get; set; }

    [JsonPropertyName("trafficLogDestination")]
    public LogDestinationModel? TrafficLogDestination { get; set; }
}
