using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineExtensionImages;


internal class VirtualMachineExtensionImagePropertiesModel
{
    [JsonPropertyName("computeRole")]
    [Required]
    public string ComputeRole { get; set; }

    [JsonPropertyName("handlerSchema")]
    [Required]
    public string HandlerSchema { get; set; }

    [JsonPropertyName("operatingSystem")]
    [Required]
    public string OperatingSystem { get; set; }

    [JsonPropertyName("supportsMultipleExtensions")]
    public bool? SupportsMultipleExtensions { get; set; }

    [JsonPropertyName("vmScaleSetEnabled")]
    public bool? VMScaleSetEnabled { get; set; }
}
