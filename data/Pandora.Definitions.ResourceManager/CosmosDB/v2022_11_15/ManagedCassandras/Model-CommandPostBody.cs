using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.ManagedCassandras;


internal class CommandPostBodyModel
{
    [JsonPropertyName("arguments")]
    public Dictionary<string, string>? Arguments { get; set; }

    [JsonPropertyName("cassandra-stop-start")]
    public bool? CassandraStopStart { get; set; }

    [JsonPropertyName("command")]
    [Required]
    public string Command { get; set; }

    [JsonPropertyName("host")]
    [Required]
    public string Host { get; set; }

    [JsonPropertyName("readwrite")]
    public bool? Readwrite { get; set; }
}
