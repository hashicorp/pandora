// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsCloudPCOverviewModel
{
    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusFailed")]
    public int? NumberOfCloudPCConnectionStatusFailed { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusPassed")]
    public int? NumberOfCloudPCConnectionStatusPassed { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusPending")]
    public int? NumberOfCloudPCConnectionStatusPending { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusRunning")]
    public int? NumberOfCloudPCConnectionStatusRunning { get; set; }

    [JsonPropertyName("numberOfCloudPcConnectionStatusUnkownFutureValue")]
    public int? NumberOfCloudPCConnectionStatusUnkownFutureValue { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusDeprovisioning")]
    public int? NumberOfCloudPCStatusDeprovisioning { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusFailed")]
    public int? NumberOfCloudPCStatusFailed { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusInGracePeriod")]
    public int? NumberOfCloudPCStatusInGracePeriod { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusNotProvisioned")]
    public int? NumberOfCloudPCStatusNotProvisioned { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusProvisioned")]
    public int? NumberOfCloudPCStatusProvisioned { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusProvisioning")]
    public int? NumberOfCloudPCStatusProvisioning { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusUnknown")]
    public int? NumberOfCloudPCStatusUnknown { get; set; }

    [JsonPropertyName("numberOfCloudPcStatusUpgrading")]
    public int? NumberOfCloudPCStatusUpgrading { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("totalBusinessLicenses")]
    public int? TotalBusinessLicenses { get; set; }

    [JsonPropertyName("totalCloudPcConnectionStatus")]
    public int? TotalCloudPCConnectionStatus { get; set; }

    [JsonPropertyName("totalCloudPcStatus")]
    public int? TotalCloudPCStatus { get; set; }

    [JsonPropertyName("totalEnterpriseLicenses")]
    public int? TotalEnterpriseLicenses { get; set; }
}
