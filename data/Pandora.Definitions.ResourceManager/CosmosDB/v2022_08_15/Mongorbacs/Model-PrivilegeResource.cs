using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.Mongorbacs;


internal class PrivilegeResourceModel
{
    [JsonPropertyName("collection")]
    public string? Collection { get; set; }

    [JsonPropertyName("db")]
    public string? Db { get; set; }
}
