using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;


internal class AmlComputePropertiesModel
{
    [JsonPropertyName("allocationState")]
    public AllocationStateConstant? AllocationState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("allocationStateTransitionTime")]
    public DateTime? AllocationStateTransitionTime { get; set; }

    [JsonPropertyName("currentNodeCount")]
    public int? CurrentNodeCount { get; set; }

    [JsonPropertyName("enableNodePublicIp")]
    public bool? EnableNodePublicIP { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorResponseModel>? Errors { get; set; }

    [JsonPropertyName("isolatedNetwork")]
    public bool? IsolatedNetwork { get; set; }

    [JsonPropertyName("nodeStateCounts")]
    public NodeStateCountsModel? NodeStateCounts { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("propertyBag")]
    public object? PropertyBag { get; set; }

    [JsonPropertyName("remoteLoginPortPublicAccess")]
    public RemoteLoginPortPublicAccessConstant? RemoteLoginPortPublicAccess { get; set; }

    [JsonPropertyName("scaleSettings")]
    public ScaleSettingsModel? ScaleSettings { get; set; }

    [JsonPropertyName("subnet")]
    public ResourceIdModel? Subnet { get; set; }

    [JsonPropertyName("targetNodeCount")]
    public int? TargetNodeCount { get; set; }

    [JsonPropertyName("userAccountCredentials")]
    public UserAccountCredentialsModel? UserAccountCredentials { get; set; }

    [JsonPropertyName("vmPriority")]
    public VMPriorityConstant? VMPriority { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VMSize { get; set; }

    [JsonPropertyName("virtualMachineImage")]
    public VirtualMachineImageModel? VirtualMachineImage { get; set; }
}
