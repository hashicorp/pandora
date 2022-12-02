using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.PrivateEndpoint;


internal class ClientScriptForConnectModel
{
    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("scriptContent")]
    public string? ScriptContent { get; set; }

    [JsonPropertyName("scriptExtension")]
    public string? ScriptExtension { get; set; }

    [JsonPropertyName("scriptNameSuffix")]
    public string? ScriptNameSuffix { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
