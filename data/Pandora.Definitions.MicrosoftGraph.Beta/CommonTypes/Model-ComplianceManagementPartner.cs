// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ComplianceManagementPartnerModel
{
    [JsonPropertyName("androidEnrollmentAssignments")]
    public List<ComplianceManagementPartnerAssignmentModel>? AndroidEnrollmentAssignments { get; set; }

    [JsonPropertyName("androidOnboarded")]
    public bool? AndroidOnboarded { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("iosEnrollmentAssignments")]
    public List<ComplianceManagementPartnerAssignmentModel>? IosEnrollmentAssignments { get; set; }

    [JsonPropertyName("iosOnboarded")]
    public bool? IosOnboarded { get; set; }

    [JsonPropertyName("lastHeartbeatDateTime")]
    public DateTime? LastHeartbeatDateTime { get; set; }

    [JsonPropertyName("macOsEnrollmentAssignments")]
    public List<ComplianceManagementPartnerAssignmentModel>? MacOsEnrollmentAssignments { get; set; }

    [JsonPropertyName("macOsOnboarded")]
    public bool? MacOsOnboarded { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("partnerState")]
    public DeviceManagementPartnerTenantStateConstant? PartnerState { get; set; }
}
