using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;


internal class IPsecPolicyModel
{
    [JsonPropertyName("dhGroup")]
    [Required]
    public DhGroupConstant DhGroup { get; set; }

    [JsonPropertyName("ipsecEncryption")]
    [Required]
    public IPsecEncryptionConstant IPsecEncryption { get; set; }

    [JsonPropertyName("ipsecIntegrity")]
    [Required]
    public IPsecIntegrityConstant IPsecIntegrity { get; set; }

    [JsonPropertyName("ikeEncryption")]
    [Required]
    public IkeEncryptionConstant IkeEncryption { get; set; }

    [JsonPropertyName("ikeIntegrity")]
    [Required]
    public IkeIntegrityConstant IkeIntegrity { get; set; }

    [JsonPropertyName("pfsGroup")]
    [Required]
    public PfsGroupConstant PfsGroup { get; set; }

    [JsonPropertyName("saDataSizeKilobytes")]
    [Required]
    public int SaDataSizeKilobytes { get; set; }

    [JsonPropertyName("saLifeTimeSeconds")]
    [Required]
    public int SaLifeTimeSeconds { get; set; }
}
