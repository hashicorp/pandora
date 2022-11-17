using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.ManagedCassandras;


internal class ConnectionErrorModel
{
    [JsonPropertyName("connectionState")]
    public ConnectionStateConstant? ConnectionState { get; set; }

    [JsonPropertyName("exception")]
    public string? Exception { get; set; }

    [JsonPropertyName("iPFrom")]
    public string? IPFrom { get; set; }

    [JsonPropertyName("iPTo")]
    public string? IPTo { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }
}
