using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PrivateClouds;


internal class PrivateCloudUpdatePropertiesModel
{
    [JsonPropertyName("availability")]
    public AvailabilityPropertiesModel? Availability { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionModel? Encryption { get; set; }

    [JsonPropertyName("identitySources")]
    public List<IdentitySourceModel>? IdentitySources { get; set; }

    [JsonPropertyName("internet")]
    public InternetEnumConstant? Internet { get; set; }

    [JsonPropertyName("managementCluster")]
    public CommonClusterPropertiesModel? ManagementCluster { get; set; }
}
