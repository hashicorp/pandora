using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2024_01_01.ConnectedClusters;


internal class ListClusterUserCredentialPropertiesModel
{
    [JsonPropertyName("authenticationMethod")]
    [Required]
    public AuthenticationMethodConstant AuthenticationMethod { get; set; }

    [JsonPropertyName("clientProxy")]
    [Required]
    public bool ClientProxy { get; set; }
}
