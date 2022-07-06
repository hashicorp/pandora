using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.Scripts;


internal class ScriptPropertiesModel
{
    [JsonPropertyName("continueOnErrors")]
    public bool? ContinueOnErrors { get; set; }

    [JsonPropertyName("forceUpdateTag")]
    public string? ForceUpdateTag { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("scriptUrl")]
    [Required]
    public string ScriptUrl { get; set; }

    [JsonPropertyName("scriptUrlSasToken")]
    [Required]
    public string ScriptUrlSasToken { get; set; }
}
