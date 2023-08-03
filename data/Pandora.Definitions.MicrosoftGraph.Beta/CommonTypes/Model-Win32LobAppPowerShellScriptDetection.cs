// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Win32LobAppPowerShellScriptDetectionModel
{
    [JsonPropertyName("enforceSignatureCheck")]
    public bool? EnforceSignatureCheck { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("runAs32Bit")]
    public bool? RunAs32Bit { get; set; }

    [JsonPropertyName("scriptContent")]
    public string? ScriptContent { get; set; }
}
