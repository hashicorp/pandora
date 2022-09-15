using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachines;


internal class VirtualMachineAssessPatchesResultModel
{
    [JsonPropertyName("assessmentActivityId")]
    public string? AssessmentActivityId { get; set; }

    [JsonPropertyName("availablePatches")]
    public List<VirtualMachineSoftwarePatchPropertiesModel>? AvailablePatches { get; set; }

    [JsonPropertyName("criticalAndSecurityPatchCount")]
    public int? CriticalAndSecurityPatchCount { get; set; }

    [JsonPropertyName("error")]
    public ApiErrorModel? Error { get; set; }

    [JsonPropertyName("otherPatchCount")]
    public int? OtherPatchCount { get; set; }

    [JsonPropertyName("rebootPending")]
    public bool? RebootPending { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public PatchOperationStatusConstant? Status { get; set; }
}
