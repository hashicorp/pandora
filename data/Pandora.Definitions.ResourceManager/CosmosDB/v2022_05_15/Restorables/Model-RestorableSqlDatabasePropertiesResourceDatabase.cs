using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.Restorables;


internal class RestorableSqlDatabasePropertiesResourceDatabaseModel
{
    [JsonPropertyName("_colls")]
    public string? Colls { get; set; }

    [JsonPropertyName("_etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("_rid")]
    public string? Rid { get; set; }

    [JsonPropertyName("_self")]
    public string? Self { get; set; }

    [JsonPropertyName("_ts")]
    public float? Ts { get; set; }

    [JsonPropertyName("_users")]
    public string? Users { get; set; }
}
