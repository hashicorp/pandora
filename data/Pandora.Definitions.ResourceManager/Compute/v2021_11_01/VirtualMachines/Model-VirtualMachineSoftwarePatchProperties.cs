using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;


internal class VirtualMachineSoftwarePatchPropertiesModel
{
    [JsonPropertyName("activityId")]
    public string? ActivityId { get; set; }

    [JsonPropertyName("assessmentState")]
    public PatchAssessmentStateConstant? AssessmentState { get; set; }

    [JsonPropertyName("classifications")]
    public List<string>? Classifications { get; set; }

    [JsonPropertyName("kbId")]
    public string? KbId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("patchId")]
    public string? PatchId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("publishedDate")]
    public DateTime? PublishedDate { get; set; }

    [JsonPropertyName("rebootBehavior")]
    public VMGuestPatchRebootBehaviorConstant? RebootBehavior { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
