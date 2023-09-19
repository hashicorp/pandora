// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConditionalAccessConditionSetModel
{
    [JsonPropertyName("applications")]
    public ConditionalAccessApplicationsModel? Applications { get; set; }

    [JsonPropertyName("clientAppTypes")]
    public List<ConditionalAccessConditionSetClientAppTypesConstant>? ClientAppTypes { get; set; }

    [JsonPropertyName("clientApplications")]
    public ConditionalAccessClientApplicationsModel? ClientApplications { get; set; }

    [JsonPropertyName("devices")]
    public ConditionalAccessDevicesModel? Devices { get; set; }

    [JsonPropertyName("locations")]
    public ConditionalAccessLocationsModel? Locations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platforms")]
    public ConditionalAccessPlatformsModel? Platforms { get; set; }

    [JsonPropertyName("servicePrincipalRiskLevels")]
    public List<ConditionalAccessConditionSetServicePrincipalRiskLevelsConstant>? ServicePrincipalRiskLevels { get; set; }

    [JsonPropertyName("signInRiskLevels")]
    public List<ConditionalAccessConditionSetSignInRiskLevelsConstant>? SignInRiskLevels { get; set; }

    [JsonPropertyName("userRiskLevels")]
    public List<ConditionalAccessConditionSetUserRiskLevelsConstant>? UserRiskLevels { get; set; }

    [JsonPropertyName("users")]
    public ConditionalAccessUsersModel? Users { get; set; }
}
