using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Application;


internal class ArmRollingUpgradeMonitoringPolicyModel
{
    [JsonPropertyName("failureAction")]
    public ArmUpgradeFailureActionConstant? FailureAction { get; set; }

    [JsonPropertyName("healthCheckRetryTimeout")]
    public string? HealthCheckRetryTimeout { get; set; }

    [JsonPropertyName("healthCheckStableDuration")]
    public string? HealthCheckStableDuration { get; set; }

    [JsonPropertyName("healthCheckWaitDuration")]
    public string? HealthCheckWaitDuration { get; set; }

    [JsonPropertyName("upgradeDomainTimeout")]
    public string? UpgradeDomainTimeout { get; set; }

    [JsonPropertyName("upgradeTimeout")]
    public string? UpgradeTimeout { get; set; }
}
