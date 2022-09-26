using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;


internal class AvailablePatchSummaryModel
{
    [JsonPropertyName("assessmentActivityId")]
    public string? AssessmentActivityId { get; set; }

    [JsonPropertyName("criticalAndSecurityPatchCount")]
    public int? CriticalAndSecurityPatchCount { get; set; }

    [JsonPropertyName("error")]
    public ApiErrorModel? Error { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("otherPatchCount")]
    public int? OtherPatchCount { get; set; }

    [JsonPropertyName("rebootPending")]
    public bool? RebootPending { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public PatchOperationStatusConstant? Status { get; set; }
}
