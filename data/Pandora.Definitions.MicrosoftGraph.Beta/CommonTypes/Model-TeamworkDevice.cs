// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDeviceModel
{
    [JsonPropertyName("activity")]
    public TeamworkDeviceActivityModel? Activity { get; set; }

    [JsonPropertyName("activityState")]
    public TeamworkDeviceActivityStateConstant? ActivityState { get; set; }

    [JsonPropertyName("companyAssetTag")]
    public string? CompanyAssetTag { get; set; }

    [JsonPropertyName("configuration")]
    public TeamworkDeviceConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("currentUser")]
    public TeamworkUserIdentityModel? CurrentUser { get; set; }

    [JsonPropertyName("deviceType")]
    public TeamworkDeviceTypeConstant? DeviceType { get; set; }

    [JsonPropertyName("hardwareDetail")]
    public TeamworkHardwareDetailModel? HardwareDetail { get; set; }

    [JsonPropertyName("health")]
    public TeamworkDeviceHealthModel? Health { get; set; }

    [JsonPropertyName("healthStatus")]
    public TeamworkDeviceHealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<TeamworkDeviceOperationModel>? Operations { get; set; }
}
