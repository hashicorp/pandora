using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsWorkloadClassifiers;


internal class WorkloadClassifierPropertiesModel
{
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    [JsonPropertyName("endTime")]
    public string? EndTime { get; set; }

    [JsonPropertyName("importance")]
    public string? Importance { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("memberName")]
    [Required]
    public string MemberName { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }
}
