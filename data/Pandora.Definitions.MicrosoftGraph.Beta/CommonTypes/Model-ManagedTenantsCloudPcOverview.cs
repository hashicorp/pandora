// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsCloudPcOverviewModel
{
    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusFailed")]
    public int? NumberOfCloudPcConnectionStatusFailed { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusPassed")]
    public int? NumberOfCloudPcConnectionStatusPassed { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusPending")]
    public int? NumberOfCloudPcConnectionStatusPending { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusRunning")]
    public int? NumberOfCloudPcConnectionStatusRunning { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusUnkownFutureValue")]
    public int? NumberOfCloudPcConnectionStatusUnkownFutureValue { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusDeprovisioning")]
    public int? NumberOfCloudPcStatusDeprovisioning { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusFailed")]
    public int? NumberOfCloudPcStatusFailed { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusInGracePeriod")]
    public int? NumberOfCloudPcStatusInGracePeriod { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusNotProvisioned")]
    public int? NumberOfCloudPcStatusNotProvisioned { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusProvisioned")]
    public int? NumberOfCloudPcStatusProvisioned { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusProvisioning")]
    public int? NumberOfCloudPcStatusProvisioning { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusUnknown")]
    public int? NumberOfCloudPcStatusUnknown { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusUpgrading")]
    public int? NumberOfCloudPcStatusUpgrading { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("totalBusinessLicenses")]
    public int? TotalBusinessLicenses { get; set; }

    [JsonPropertyName("totalCloudPcConnectionStatus")]
    public int? TotalCloudPcConnectionStatus { get; set; }

    [JsonPropertyName("totalCloudPcStatus")]
    public int? TotalCloudPcStatus { get; set; }

    [JsonPropertyName("totalEnterpriseLicenses")]
    public int? TotalEnterpriseLicenses { get; set; }
}
