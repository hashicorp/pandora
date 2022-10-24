using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class CIFSMountConfigurationModel
{
    [JsonPropertyName("mountOptions")]
    public string? MountOptions { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }

    [JsonPropertyName("relativeMountPath")]
    [Required]
    public string RelativeMountPath { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public string Source { get; set; }

    [JsonPropertyName("username")]
    [Required]
    public string Username { get; set; }
}
