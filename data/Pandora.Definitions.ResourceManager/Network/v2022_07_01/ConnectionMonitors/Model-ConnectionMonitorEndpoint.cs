using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;


internal class ConnectionMonitorEndpointModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("coverageLevel")]
    public CoverageLevelConstant? CoverageLevel { get; set; }

    [JsonPropertyName("filter")]
    public ConnectionMonitorEndpointFilterModel? Filter { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("scope")]
    public ConnectionMonitorEndpointScopeModel? Scope { get; set; }

    [JsonPropertyName("type")]
    public EndpointTypeConstant? Type { get; set; }
}
