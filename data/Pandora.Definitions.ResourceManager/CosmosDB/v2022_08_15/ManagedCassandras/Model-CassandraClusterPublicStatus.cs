using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.ManagedCassandras;


internal class CassandraClusterPublicStatusModel
{
    [JsonPropertyName("connectionErrors")]
    public List<ConnectionErrorModel>? ConnectionErrors { get; set; }

    [JsonPropertyName("dataCenters")]
    public List<CassandraClusterPublicStatusDataCentersInlinedModel>? DataCenters { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("reaperStatus")]
    public ManagedCassandraReaperStatusModel? ReaperStatus { get; set; }
}
