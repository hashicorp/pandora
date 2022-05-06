using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds;


internal class PrivateCloudUpdatePropertiesModel
{
    [JsonPropertyName("identitySources")]
    public List<IdentitySourceModel>? IdentitySources { get; set; }

    [JsonPropertyName("internet")]
    public InternetEnumConstant? Internet { get; set; }

    [JsonPropertyName("managementCluster")]
    public ManagementClusterModel? ManagementCluster { get; set; }
}
