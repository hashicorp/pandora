using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ShareSubscription;


internal class ConsumerSourceDataSetPropertiesModel
{
    [JsonPropertyName("dataSetId")]
    public string? DataSetId { get; set; }

    [JsonPropertyName("dataSetLocation")]
    public string? DataSetLocation { get; set; }

    [JsonPropertyName("dataSetName")]
    public string? DataSetName { get; set; }

    [JsonPropertyName("dataSetPath")]
    public string? DataSetPath { get; set; }

    [JsonPropertyName("dataSetType")]
    public DataSetTypeConstant? DataSetType { get; set; }
}
