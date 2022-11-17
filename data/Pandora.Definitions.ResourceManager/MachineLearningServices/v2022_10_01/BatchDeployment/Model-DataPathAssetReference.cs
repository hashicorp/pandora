using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchDeployment;

[ValueForType("DataPath")]
internal class DataPathAssetReferenceModel : AssetReferenceBaseModel
{
    [JsonPropertyName("datastoreId")]
    public string? DatastoreId { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
