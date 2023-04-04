using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.HybridIdentityMetadata;


internal class HybridIdentityMetadataPropertiesModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemAssignedIdentity? Identity { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicKey")]
    public string? PublicKey { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }
}
