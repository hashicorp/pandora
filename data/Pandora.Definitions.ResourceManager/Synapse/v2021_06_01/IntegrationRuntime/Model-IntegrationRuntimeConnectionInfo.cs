using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;


internal class IntegrationRuntimeConnectionInfoModel
{
    [JsonPropertyName("hostServiceUri")]
    public string? HostServiceUri { get; set; }

    [JsonPropertyName("identityCertThumbprint")]
    public string? IdentityCertThumbprint { get; set; }

    [JsonPropertyName("isIdentityCertExprired")]
    public bool? IsIdentityCertExprired { get; set; }

    [JsonPropertyName("publicKey")]
    public string? PublicKey { get; set; }

    [JsonPropertyName("serviceToken")]
    public string? ServiceToken { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
