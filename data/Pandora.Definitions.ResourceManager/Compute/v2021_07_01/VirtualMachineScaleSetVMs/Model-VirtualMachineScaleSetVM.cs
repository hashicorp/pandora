using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetVMs;


internal class VirtualMachineScaleSetVMModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("instanceId")]
    public string? InstanceId { get; set; }

    [JsonPropertyName("location")]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("plan")]
    public PlanModel? Plan { get; set; }

    [JsonPropertyName("properties")]
    public VirtualMachineScaleSetVMPropertiesModel? Properties { get; set; }

    [JsonPropertyName("resources")]
    public List<VirtualMachineExtensionModel>? Resources { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("zones")]
    public List<string>? Zones { get; set; }
}
