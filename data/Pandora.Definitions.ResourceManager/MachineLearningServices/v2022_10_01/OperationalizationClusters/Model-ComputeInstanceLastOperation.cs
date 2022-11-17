using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OperationalizationClusters;


internal class ComputeInstanceLastOperationModel
{
    [JsonPropertyName("operationName")]
    public OperationNameConstant? OperationName { get; set; }

    [JsonPropertyName("operationStatus")]
    public OperationStatusConstant? OperationStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("operationTime")]
    public DateTime? OperationTime { get; set; }

    [JsonPropertyName("operationTrigger")]
    public OperationTriggerConstant? OperationTrigger { get; set; }
}
