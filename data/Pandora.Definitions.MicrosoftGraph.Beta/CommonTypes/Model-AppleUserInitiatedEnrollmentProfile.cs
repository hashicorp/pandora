// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AppleUserInitiatedEnrollmentProfileModel
{
    [JsonPropertyName("assignments")]
    public List<AppleEnrollmentProfileAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("availableEnrollmentTypeOptions")]
    public List<AppleOwnerTypeEnrollmentTypeModel>? AvailableEnrollmentTypeOptions { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defaultEnrollmentType")]
    public AppleUserInitiatedEnrollmentTypeConstant? DefaultEnrollmentType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public DevicePlatformTypeConstant? Platform { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }
}
