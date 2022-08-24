using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;


internal class IndexingPolicyModel
{
    [JsonPropertyName("automatic")]
    public bool? Automatic { get; set; }

    [JsonPropertyName("compositeIndexes")]
    public List<List<CompositePathModel>>? CompositeIndexes { get; set; }

    [JsonPropertyName("excludedPaths")]
    public List<ExcludedPathModel>? ExcludedPaths { get; set; }

    [JsonPropertyName("includedPaths")]
    public List<IncludedPathModel>? IncludedPaths { get; set; }

    [JsonPropertyName("indexingMode")]
    public IndexingModeConstant? IndexingMode { get; set; }

    [JsonPropertyName("spatialIndexes")]
    public List<SpatialSpecModel>? SpatialIndexes { get; set; }
}
