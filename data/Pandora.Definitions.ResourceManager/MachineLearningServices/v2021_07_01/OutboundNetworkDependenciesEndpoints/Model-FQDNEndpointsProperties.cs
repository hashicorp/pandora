using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.OutboundNetworkDependenciesEndpoints;


internal class FQDNEndpointsPropertiesModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("endpoints")]
    public List<FQDNEndpointModel>? Endpoints { get; set; }
}
