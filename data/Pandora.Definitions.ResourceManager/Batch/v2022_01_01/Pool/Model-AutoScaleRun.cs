using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class AutoScaleRunModel
{
    [JsonPropertyName("error")]
    public AutoScaleRunErrorModel? Error { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("evaluationTime")]
    [Required]
    public DateTime EvaluationTime { get; set; }

    [JsonPropertyName("results")]
    public string? Results { get; set; }
}
