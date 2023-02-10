using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.MaterializedViewsBuilder;


internal class SqlDedicatedGatewayRegionalServiceResourceModel
{
    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sqlDedicatedGatewayEndpoint")]
    public string? SqlDedicatedGatewayEndpoint { get; set; }

    [JsonPropertyName("status")]
    public ServiceStatusConstant? Status { get; set; }
}
