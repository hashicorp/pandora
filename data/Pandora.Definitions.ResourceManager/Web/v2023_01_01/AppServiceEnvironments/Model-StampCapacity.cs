using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceEnvironments;


internal class StampCapacityModel
{
    [JsonPropertyName("availableCapacity")]
    public int? AvailableCapacity { get; set; }

    [JsonPropertyName("computeMode")]
    public ComputeModeOptionsConstant? ComputeMode { get; set; }

    [JsonPropertyName("excludeFromCapacityAllocation")]
    public bool? ExcludeFromCapacityAllocation { get; set; }

    [JsonPropertyName("isApplicableForAllComputeModes")]
    public bool? IsApplicableForAllComputeModes { get; set; }

    [JsonPropertyName("isLinux")]
    public bool? IsLinux { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("siteMode")]
    public string? SiteMode { get; set; }

    [JsonPropertyName("totalCapacity")]
    public int? TotalCapacity { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }

    [JsonPropertyName("workerSize")]
    public WorkerSizeOptionsConstant? WorkerSize { get; set; }

    [JsonPropertyName("workerSizeId")]
    public int? WorkerSizeId { get; set; }
}
