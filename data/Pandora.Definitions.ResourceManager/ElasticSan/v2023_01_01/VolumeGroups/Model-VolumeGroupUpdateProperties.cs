using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.VolumeGroups;


internal class VolumeGroupUpdatePropertiesModel
{
    [JsonPropertyName("encryption")]
    public EncryptionTypeConstant? Encryption { get; set; }

    [JsonPropertyName("encryptionProperties")]
    public EncryptionPropertiesModel? EncryptionProperties { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("protocolType")]
    public StorageTargetTypeConstant? ProtocolType { get; set; }
}
