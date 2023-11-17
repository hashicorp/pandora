// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Win32CatalogAppAssignmentSettingsModel
{
    [JsonPropertyName("autoUpdateSettings")]
    public Win32LobAppAutoUpdateSettingsModel? AutoUpdateSettings { get; set; }

    [JsonPropertyName("deliveryOptimizationPriority")]
    public Win32CatalogAppAssignmentSettingsDeliveryOptimizationPriorityConstant? DeliveryOptimizationPriority { get; set; }

    [JsonPropertyName("installTimeSettings")]
    public MobileAppInstallTimeSettingsModel? InstallTimeSettings { get; set; }

    [JsonPropertyName("notifications")]
    public Win32CatalogAppAssignmentSettingsNotificationsConstant? Notifications { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("restartSettings")]
    public Win32LobAppRestartSettingsModel? RestartSettings { get; set; }
}
