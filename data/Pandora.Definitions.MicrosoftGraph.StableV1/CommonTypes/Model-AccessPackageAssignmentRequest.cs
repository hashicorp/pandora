// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentRequestModel
{
    [JsonPropertyName("accessPackage")]
    public AccessPackageModel? AccessPackage { get; set; }

    [JsonPropertyName("answers")]
    public List<AccessPackageAnswerModel>? Answers { get; set; }

    [JsonPropertyName("assignment")]
    public AccessPackageAssignmentModel? Assignment { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestType")]
    public AccessPackageRequestTypeConstant? RequestType { get; set; }

    [JsonPropertyName("requestor")]
    public AccessPackageSubjectModel? Requestor { get; set; }

    [JsonPropertyName("schedule")]
    public EntitlementManagementScheduleModel? Schedule { get; set; }

    [JsonPropertyName("state")]
    public AccessPackageRequestStateConstant? State { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
