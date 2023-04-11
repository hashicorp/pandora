using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_03_15.Services;

[ValueForType("GraphAPICompute")]
internal class GraphAPIComputeServiceResourcePropertiesModel : ServiceResourcePropertiesModel
{
    [JsonPropertyName("graphApiComputeEndpoint")]
    public string? GraphApiComputeEndpoint { get; set; }

    [JsonPropertyName("locations")]
    public List<GraphAPIComputeRegionalServiceResourceModel>? Locations { get; set; }
}
