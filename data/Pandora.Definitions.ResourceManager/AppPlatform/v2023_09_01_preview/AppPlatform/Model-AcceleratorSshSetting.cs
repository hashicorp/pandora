using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_09_01_preview.AppPlatform;

[ValueForType("SSH")]
internal class AcceleratorSshSettingModel : AcceleratorAuthSettingModel
{
    [JsonPropertyName("hostKey")]
    public string? HostKey { get; set; }

    [JsonPropertyName("hostKeyAlgorithm")]
    public string? HostKeyAlgorithm { get; set; }

    [JsonPropertyName("privateKey")]
    public string? PrivateKey { get; set; }
}
