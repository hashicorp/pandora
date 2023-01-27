using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.MonitorsResource;


internal class MonitorPropertiesModel
{
    [JsonPropertyName("datadogOrganizationProperties")]
    public DatadogOrganizationPropertiesModel? DatadogOrganizationProperties { get; set; }

    [JsonPropertyName("liftrResourceCategory")]
    public LiftrResourceCategoriesConstant? LiftrResourceCategory { get; set; }

    [JsonPropertyName("liftrResourcePreference")]
    public int? LiftrResourcePreference { get; set; }

    [JsonPropertyName("marketplaceSubscriptionStatus")]
    public MarketplaceSubscriptionStatusConstant? MarketplaceSubscriptionStatus { get; set; }

    [JsonPropertyName("monitoringStatus")]
    public MonitoringStatusConstant? MonitoringStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("userInfo")]
    public UserInfoModel? UserInfo { get; set; }
}
