using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class TrafficAnalyticsConfigurationPropertiesModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("trafficAnalyticsInterval")]
    public int? TrafficAnalyticsInterval { get; set; }

    [JsonPropertyName("workspaceId")]
    public string? WorkspaceId { get; set; }

    [JsonPropertyName("workspaceRegion")]
    public string? WorkspaceRegion { get; set; }

    [JsonPropertyName("workspaceResourceId")]
    public string? WorkspaceResourceId { get; set; }
}
