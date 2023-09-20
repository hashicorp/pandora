// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImportedAppleDeviceIdentityResultModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("discoverySource")]
    public ImportedAppleDeviceIdentityResultDiscoverySourceConstant? DiscoverySource { get; set; }

    [JsonPropertyName("enrollmentState")]
    public ImportedAppleDeviceIdentityResultEnrollmentStateConstant? EnrollmentState { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isSupervised")]
    public bool? IsSupervised { get; set; }

    [JsonPropertyName("lastContactedDateTime")]
    public DateTime? LastContactedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public ImportedAppleDeviceIdentityResultPlatformConstant? Platform { get; set; }

    [JsonPropertyName("requestedEnrollmentProfileAssignmentDateTime")]
    public DateTime? RequestedEnrollmentProfileAssignmentDateTime { get; set; }

    [JsonPropertyName("requestedEnrollmentProfileId")]
    public string? RequestedEnrollmentProfileId { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("status")]
    public bool? Status { get; set; }
}
