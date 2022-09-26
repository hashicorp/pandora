using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSetVMs;


internal class RunCommandInputModel
{
    [JsonPropertyName("commandId")]
    [Required]
    public string CommandId { get; set; }

    [JsonPropertyName("parameters")]
    public List<RunCommandInputParameterModel>? Parameters { get; set; }

    [JsonPropertyName("script")]
    public List<string>? Script { get; set; }
}
