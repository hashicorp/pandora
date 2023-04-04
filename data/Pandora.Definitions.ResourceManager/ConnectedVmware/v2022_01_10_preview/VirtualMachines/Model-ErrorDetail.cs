using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;


internal class ErrorDetailModel
{
    [JsonPropertyName("code")]
    [Required]
    public string Code { get; set; }

    [JsonPropertyName("details")]
    public List<ErrorDetailModel>? Details { get; set; }

    [JsonPropertyName("message")]
    [Required]
    public string Message { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
