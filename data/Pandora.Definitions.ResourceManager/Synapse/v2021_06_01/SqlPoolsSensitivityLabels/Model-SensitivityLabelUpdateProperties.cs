using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsSensitivityLabels;


internal class SensitivityLabelUpdatePropertiesModel
{
    [JsonPropertyName("column")]
    [Required]
    public string Column { get; set; }

    [JsonPropertyName("op")]
    [Required]
    public SensitivityLabelUpdateKindConstant Op { get; set; }

    [JsonPropertyName("schema")]
    [Required]
    public string Schema { get; set; }

    [JsonPropertyName("sensitivityLabel")]
    public SensitivityLabelModel? SensitivityLabel { get; set; }

    [JsonPropertyName("table")]
    [Required]
    public string Table { get; set; }
}
