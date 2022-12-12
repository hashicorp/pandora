using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMs;


internal class EncryptedSimUploadListModel
{
    [JsonPropertyName("azureKeyIdentifier")]
    [Required]
    public int AzureKeyIdentifier { get; set; }

    [JsonPropertyName("encryptedTransportKey")]
    [Required]
    public string EncryptedTransportKey { get; set; }

    [JsonPropertyName("signedTransportKey")]
    [Required]
    public string SignedTransportKey { get; set; }

    [MinItems(1)]
    [JsonPropertyName("sims")]
    [Required]
    public List<SimNameAndEncryptedPropertiesModel> Sims { get; set; }

    [JsonPropertyName("vendorKeyFingerprint")]
    [Required]
    public string VendorKeyFingerprint { get; set; }

    [JsonPropertyName("version")]
    [Required]
    public int Version { get; set; }
}
