using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.Machines;


internal class MachineAssessPatchesResultModel
{
    [JsonPropertyName("assessmentActivityId")]
    public string? AssessmentActivityId { get; set; }

    [JsonPropertyName("availablePatchCountByClassification")]
    public AvailablePatchCountByClassificationModel? AvailablePatchCountByClassification { get; set; }

    [JsonPropertyName("errorDetails")]
    public ErrorDetailModel? ErrorDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("patchServiceUsed")]
    public PatchServiceUsedConstant? PatchServiceUsed { get; set; }

    [JsonPropertyName("rebootPending")]
    public bool? RebootPending { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("startedBy")]
    public PatchOperationStartedByConstant? StartedBy { get; set; }

    [JsonPropertyName("status")]
    public PatchOperationStatusConstant? Status { get; set; }
}
