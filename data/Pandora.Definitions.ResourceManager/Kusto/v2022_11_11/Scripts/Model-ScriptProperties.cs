using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.Scripts;


internal class ScriptPropertiesModel
{
    [JsonPropertyName("continueOnErrors")]
    public bool? ContinueOnErrors { get; set; }

    [JsonPropertyName("forceUpdateTag")]
    public string? ForceUpdateTag { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("scriptContent")]
    public string? ScriptContent { get; set; }

    [JsonPropertyName("scriptUrl")]
    public string? ScriptUrl { get; set; }

    [JsonPropertyName("scriptUrlSasToken")]
    public string? ScriptUrlSasToken { get; set; }
}
