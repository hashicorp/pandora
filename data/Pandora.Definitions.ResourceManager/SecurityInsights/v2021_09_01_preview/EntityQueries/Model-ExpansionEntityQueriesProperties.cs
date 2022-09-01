using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.EntityQueries;


internal class ExpansionEntityQueriesPropertiesModel
{
    [JsonPropertyName("dataSources")]
    public List<string>? DataSources { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("inputEntityType")]
    public EntityTypeConstant? InputEntityType { get; set; }

    [JsonPropertyName("inputFields")]
    public List<string>? InputFields { get; set; }

    [JsonPropertyName("outputEntityTypes")]
    public List<EntityTypeConstant>? OutputEntityTypes { get; set; }

    [JsonPropertyName("queryTemplate")]
    public string? QueryTemplate { get; set; }
}
