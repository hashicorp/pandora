using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDB;


internal class DatabaseAccountListKeysResultModel
{
    [JsonPropertyName("primaryMasterKey")]
    public string? PrimaryMasterKey { get; set; }

    [JsonPropertyName("primaryReadonlyMasterKey")]
    public string? PrimaryReadonlyMasterKey { get; set; }

    [JsonPropertyName("secondaryMasterKey")]
    public string? SecondaryMasterKey { get; set; }

    [JsonPropertyName("secondaryReadonlyMasterKey")]
    public string? SecondaryReadonlyMasterKey { get; set; }
}
