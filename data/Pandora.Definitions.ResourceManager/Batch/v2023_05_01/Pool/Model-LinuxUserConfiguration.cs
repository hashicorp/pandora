using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.Pool;


internal class LinuxUserConfigurationModel
{
    [JsonPropertyName("gid")]
    public int? Gid { get; set; }

    [JsonPropertyName("sshPrivateKey")]
    public string? SshPrivateKey { get; set; }

    [JsonPropertyName("uid")]
    public int? Uid { get; set; }
}
