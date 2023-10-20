using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;


internal abstract class MonitoringInputDataBaseModel
{
    [JsonPropertyName("columns")]
    public Dictionary<string, string>? Columns { get; set; }

    [JsonPropertyName("dataContext")]
    public string? DataContext { get; set; }

    [JsonPropertyName("inputDataType")]
    [ProvidesTypeHint]
    [Required]
    public MonitoringInputDataTypeConstant InputDataType { get; set; }

    [JsonPropertyName("jobInputType")]
    [Required]
    public JobInputTypeConstant JobInputType { get; set; }

    [JsonPropertyName("uri")]
    [Required]
    public string Uri { get; set; }
}
