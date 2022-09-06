using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.VolumeGroups;


internal class VolumeGroupPropertiesModel
{
    [JsonPropertyName("encryption")]
    public EncryptionTypeConstant? Encryption { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("protocolType")]
    public StorageTargetTypeConstant? ProtocolType { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStatesConstant? ProvisioningState { get; set; }
}
