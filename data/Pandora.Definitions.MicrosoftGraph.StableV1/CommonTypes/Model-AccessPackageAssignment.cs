// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentModel
{
    [JsonPropertyName("accessPackage")]
    public AccessPackageModel? AccessPackage { get; set; }

    [JsonPropertyName("assignmentPolicy")]
    public AccessPackageAssignmentPolicyModel? AssignmentPolicy { get; set; }

    [JsonPropertyName("expiredDateTime")]
    public DateTime? ExpiredDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schedule")]
    public EntitlementManagementScheduleModel? Schedule { get; set; }

    [JsonPropertyName("state")]
    public AccessPackageAssignmentStateConstant? State { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("target")]
    public AccessPackageSubjectModel? Target { get; set; }
}
