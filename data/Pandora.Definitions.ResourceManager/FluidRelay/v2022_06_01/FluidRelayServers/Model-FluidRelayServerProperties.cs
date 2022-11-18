using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_06_01.FluidRelayServers;


internal class FluidRelayServerPropertiesModel
{
    [JsonPropertyName("encryption")]
    public EncryptionPropertiesModel? Encryption { get; set; }

    [JsonPropertyName("fluidRelayEndpoints")]
    public FluidRelayEndpointsModel? FluidRelayEndpoints { get; set; }

    [JsonPropertyName("frsTenantId")]
    public string? FrsTenantId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("storagesku")]
    public StorageSKUConstant? Storagesku { get; set; }
}
