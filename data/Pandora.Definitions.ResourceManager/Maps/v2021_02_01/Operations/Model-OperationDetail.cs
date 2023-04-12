using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Operations;


internal class OperationDetailModel
{
    [JsonPropertyName("display")]
    public OperationDisplayModel? Display { get; set; }

    [JsonPropertyName("isDataAction")]
    public bool? IsDataAction { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    [JsonPropertyName("properties")]
    public OperationPropertiesModel? Properties { get; set; }
}
