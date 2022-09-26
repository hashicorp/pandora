using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;


internal class VirtualMachineCaptureResultModel
{
    [JsonPropertyName("contentVersion")]
    public string? ContentVersion { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("resources")]
    public List<object>? Resources { get; set; }

    [JsonPropertyName("$schema")]
    public string? Schema { get; set; }
}
