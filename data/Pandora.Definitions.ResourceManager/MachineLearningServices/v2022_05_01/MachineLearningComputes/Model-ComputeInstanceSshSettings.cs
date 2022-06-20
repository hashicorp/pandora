using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;


internal class ComputeInstanceSshSettingsModel
{
    [JsonPropertyName("adminPublicKey")]
    public string? AdminPublicKey { get; set; }

    [JsonPropertyName("adminUserName")]
    public string? AdminUserName { get; set; }

    [JsonPropertyName("sshPort")]
    public int? SshPort { get; set; }

    [JsonPropertyName("sshPublicAccess")]
    public SshPublicAccessConstant? SshPublicAccess { get; set; }
}
