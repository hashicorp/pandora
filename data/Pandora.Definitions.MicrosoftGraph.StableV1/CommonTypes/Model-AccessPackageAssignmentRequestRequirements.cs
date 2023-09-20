// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentRequestRequirementsModel
{
    [JsonPropertyName("allowCustomAssignmentSchedule")]
    public bool? AllowCustomAssignmentSchedule { get; set; }

    [JsonPropertyName("isApprovalRequiredForAdd")]
    public bool? IsApprovalRequiredForAdd { get; set; }

    [JsonPropertyName("isApprovalRequiredForUpdate")]
    public bool? IsApprovalRequiredForUpdate { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyDescription")]
    public string? PolicyDescription { get; set; }

    [JsonPropertyName("policyDisplayName")]
    public string? PolicyDisplayName { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("questions")]
    public List<AccessPackageQuestionModel>? Questions { get; set; }

    [JsonPropertyName("schedule")]
    public EntitlementManagementScheduleModel? Schedule { get; set; }
}
