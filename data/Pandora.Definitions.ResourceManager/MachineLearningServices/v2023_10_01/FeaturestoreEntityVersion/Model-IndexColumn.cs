using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.FeaturestoreEntityVersion;


internal class IndexColumnModel
{
    [JsonPropertyName("columnName")]
    public string? ColumnName { get; set; }

    [JsonPropertyName("dataType")]
    public FeatureDataTypeConstant? DataType { get; set; }
}
