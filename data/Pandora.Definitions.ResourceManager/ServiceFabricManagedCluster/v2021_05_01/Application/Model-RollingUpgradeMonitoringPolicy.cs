using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Application;


internal class RollingUpgradeMonitoringPolicyModel
{
    [JsonPropertyName("failureAction")]
    [Required]
    public FailureActionConstant FailureAction { get; set; }

    [JsonPropertyName("healthCheckRetryTimeout")]
    [Required]
    public string HealthCheckRetryTimeout { get; set; }

    [JsonPropertyName("healthCheckStableDuration")]
    [Required]
    public string HealthCheckStableDuration { get; set; }

    [JsonPropertyName("healthCheckWaitDuration")]
    [Required]
    public string HealthCheckWaitDuration { get; set; }

    [JsonPropertyName("upgradeDomainTimeout")]
    [Required]
    public string UpgradeDomainTimeout { get; set; }

    [JsonPropertyName("upgradeTimeout")]
    [Required]
    public string UpgradeTimeout { get; set; }
}
