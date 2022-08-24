using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;


internal class DatabaseAccountUpdateParametersModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.LegacySystemAndUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("properties")]
    public DatabaseAccountUpdatePropertiesModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
