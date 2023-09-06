using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ClusterAvailableUpgradeVersionModel
{
    [JsonPropertyName("controlImpact")]
    public ControlImpactConstant? ControlImpact { get; set; }

    [JsonPropertyName("expectedDuration")]
    public string? ExpectedDuration { get; set; }

    [JsonPropertyName("impactDescription")]
    public string? ImpactDescription { get; set; }

    [JsonPropertyName("supportExpiryDate")]
    public string? SupportExpiryDate { get; set; }

    [JsonPropertyName("targetClusterVersion")]
    public string? TargetClusterVersion { get; set; }

    [JsonPropertyName("workloadImpact")]
    public WorkloadImpactConstant? WorkloadImpact { get; set; }
}
