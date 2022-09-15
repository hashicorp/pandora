using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetVMExtensions;


internal class VirtualMachineExtensionInstanceViewModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("statuses")]
    public List<InstanceViewStatusModel>? Statuses { get; set; }

    [JsonPropertyName("substatuses")]
    public List<InstanceViewStatusModel>? Substatuses { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("typeHandlerVersion")]
    public string? TypeHandlerVersion { get; set; }
}
