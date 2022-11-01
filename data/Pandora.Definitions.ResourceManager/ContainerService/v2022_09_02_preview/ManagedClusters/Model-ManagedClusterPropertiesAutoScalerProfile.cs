using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.ManagedClusters;


internal class ManagedClusterPropertiesAutoScalerProfileModel
{
    [JsonPropertyName("balance-similar-node-groups")]
    public string? BalanceSimilarNodeGroups { get; set; }

    [JsonPropertyName("expander")]
    public ExpanderConstant? Expander { get; set; }

    [JsonPropertyName("max-empty-bulk-delete")]
    public string? MaxEmptyBulkDelete { get; set; }

    [JsonPropertyName("max-graceful-termination-sec")]
    public string? MaxGracefulTerminationSec { get; set; }

    [JsonPropertyName("max-node-provision-time")]
    public string? MaxNodeProvisionTime { get; set; }

    [JsonPropertyName("max-total-unready-percentage")]
    public string? MaxTotalUnreadyPercentage { get; set; }

    [JsonPropertyName("new-pod-scale-up-delay")]
    public string? NewPodScaleUpDelay { get; set; }

    [JsonPropertyName("ok-total-unready-count")]
    public string? OkTotalUnreadyCount { get; set; }

    [JsonPropertyName("scale-down-delay-after-add")]
    public string? ScaleDownDelayAfterAdd { get; set; }

    [JsonPropertyName("scale-down-delay-after-delete")]
    public string? ScaleDownDelayAfterDelete { get; set; }

    [JsonPropertyName("scale-down-delay-after-failure")]
    public string? ScaleDownDelayAfterFailure { get; set; }

    [JsonPropertyName("scale-down-unneeded-time")]
    public string? ScaleDownUnneededTime { get; set; }

    [JsonPropertyName("scale-down-unready-time")]
    public string? ScaleDownUnreadyTime { get; set; }

    [JsonPropertyName("scale-down-utilization-threshold")]
    public string? ScaleDownUtilizationThreshold { get; set; }

    [JsonPropertyName("scan-interval")]
    public string? ScanInterval { get; set; }

    [JsonPropertyName("skip-nodes-with-local-storage")]
    public string? SkipNodesWithLocalStorage { get; set; }

    [JsonPropertyName("skip-nodes-with-system-pods")]
    public string? SkipNodesWithSystemPods { get; set; }
}
