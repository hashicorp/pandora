using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntimes;


internal class IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpointModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("endpoints")]
    public List<IntegrationRuntimeOutboundNetworkDependenciesEndpointModel>? Endpoints { get; set; }
}
