using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.CosmosDB;


internal class IndexesModel
{
    [JsonPropertyName("dataType")]
    public DataTypeConstant? DataType { get; set; }

    [JsonPropertyName("kind")]
    public IndexKindConstant? Kind { get; set; }

    [JsonPropertyName("precision")]
    public int? Precision { get; set; }
}
