using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_06_01.FluidRelayServers;


internal class FluidRelayEndpointsModel
{
    [JsonPropertyName("ordererEndpoints")]
    public List<string>? OrdererEndpoints { get; set; }

    [JsonPropertyName("serviceEndpoints")]
    public List<string>? ServiceEndpoints { get; set; }

    [JsonPropertyName("storageEndpoints")]
    public List<string>? StorageEndpoints { get; set; }
}
