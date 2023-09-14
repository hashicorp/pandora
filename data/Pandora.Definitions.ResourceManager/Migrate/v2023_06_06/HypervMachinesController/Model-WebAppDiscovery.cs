using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervMachinesController;


internal class WebAppDiscoveryModel
{
    [JsonPropertyName("discoveryScopeStatus")]
    public DiscoveryScopeStatusConstant? DiscoveryScopeStatus { get; set; }

    [JsonPropertyName("totalWebApplicationCount")]
    public int? TotalWebApplicationCount { get; set; }

    [JsonPropertyName("totalWebServerCount")]
    public int? TotalWebServerCount { get; set; }
}
