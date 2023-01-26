using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteLinks;


internal class ExpressRouteLinkMacSecConfigModel
{
    [JsonPropertyName("cakSecretIdentifier")]
    public string? CakSecretIdentifier { get; set; }

    [JsonPropertyName("cipher")]
    public ExpressRouteLinkMacSecCipherConstant? Cipher { get; set; }

    [JsonPropertyName("cknSecretIdentifier")]
    public string? CknSecretIdentifier { get; set; }

    [JsonPropertyName("sciState")]
    public ExpressRouteLinkMacSecSciStateConstant? SciState { get; set; }
}
