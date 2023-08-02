// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConditionalAccessConditionSetModel
{
    [JsonPropertyName("applications")]
    public ConditionalAccessApplicationsModel? Applications { get; set; }

    [JsonPropertyName("clientAppTypes")]
    public List<ConditionalAccessClientAppConstant>? ClientAppTypes { get; set; }

    [JsonPropertyName("clientApplications")]
    public ConditionalAccessClientApplicationsModel? ClientApplications { get; set; }

    [JsonPropertyName("deviceStates")]
    public ConditionalAccessDeviceStatesModel? DeviceStates { get; set; }

    [JsonPropertyName("devices")]
    public ConditionalAccessDevicesModel? Devices { get; set; }

    [JsonPropertyName("locations")]
    public ConditionalAccessLocationsModel? Locations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platforms")]
    public ConditionalAccessPlatformsModel? Platforms { get; set; }

    [JsonPropertyName("servicePrincipalRiskLevels")]
    public List<RiskLevelConstant>? ServicePrincipalRiskLevels { get; set; }

    [JsonPropertyName("signInRiskLevels")]
    public List<RiskLevelConstant>? SignInRiskLevels { get; set; }

    [JsonPropertyName("userRiskLevels")]
    public List<RiskLevelConstant>? UserRiskLevels { get; set; }

    [JsonPropertyName("users")]
    public ConditionalAccessUsersModel? Users { get; set; }
}
