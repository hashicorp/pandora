using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;


internal class AzureMachineLearningWebServiceInputsModel
{
    [JsonPropertyName("columnNames")]
    public List<AzureMachineLearningWebServiceInputColumnModel>? ColumnNames { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
