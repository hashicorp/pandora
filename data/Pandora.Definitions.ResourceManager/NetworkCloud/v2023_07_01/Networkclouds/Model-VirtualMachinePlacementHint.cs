using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class VirtualMachinePlacementHintModel
{
    [JsonPropertyName("hintType")]
    [Required]
    public VirtualMachinePlacementHintTypeConstant HintType { get; set; }

    [JsonPropertyName("resourceId")]
    [Required]
    public string ResourceId { get; set; }

    [JsonPropertyName("schedulingExecution")]
    [Required]
    public VirtualMachineSchedulingExecutionConstant SchedulingExecution { get; set; }

    [JsonPropertyName("scope")]
    [Required]
    public VirtualMachinePlacementHintPodAffinityScopeConstant Scope { get; set; }
}
