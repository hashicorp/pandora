using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.DataSet;


internal class KustoDatabaseDataSetPropertiesModel
{
    [JsonPropertyName("dataSetId")]
    public string? DataSetId { get; set; }

    [JsonPropertyName("kustoDatabaseResourceId")]
    [Required]
    public string KustoDatabaseResourceId { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
