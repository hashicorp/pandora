using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetVMs;


internal class VirtualMachineAgentInstanceViewModel
{
    [JsonPropertyName("extensionHandlers")]
    public List<VirtualMachineExtensionHandlerInstanceViewModel>? ExtensionHandlers { get; set; }

    [JsonPropertyName("statuses")]
    public List<InstanceViewStatusModel>? Statuses { get; set; }

    [JsonPropertyName("vmAgentVersion")]
    public string? VmAgentVersion { get; set; }
}
