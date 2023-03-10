using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2021_10_15.CosmosDB;


internal class ContainerPartitionKeyModel
{
    [JsonPropertyName("kind")]
    public PartitionKindConstant? Kind { get; set; }

    [JsonPropertyName("paths")]
    public List<string>? Paths { get; set; }

    [JsonPropertyName("systemKey")]
    public bool? SystemKey { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
