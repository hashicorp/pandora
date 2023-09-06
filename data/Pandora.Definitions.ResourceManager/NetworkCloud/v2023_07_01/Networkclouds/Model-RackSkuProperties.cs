using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class RackSkuPropertiesModel
{
    [JsonPropertyName("computeMachines")]
    public List<MachineSkuSlotModel>? ComputeMachines { get; set; }

    [JsonPropertyName("controllerMachines")]
    public List<MachineSkuSlotModel>? ControllerMachines { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("maxClusterSlots")]
    public int? MaxClusterSlots { get; set; }

    [JsonPropertyName("provisioningState")]
    public RackSkuProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rackType")]
    public RackSkuTypeConstant? RackType { get; set; }

    [JsonPropertyName("storageAppliances")]
    public List<StorageApplianceSkuSlotModel>? StorageAppliances { get; set; }

    [JsonPropertyName("supportedRackSkuIds")]
    public List<string>? SupportedRackSkuIds { get; set; }
}
