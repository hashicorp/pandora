using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MasterSitesController;


internal class MasterSitePropertiesModel
{
    [JsonPropertyName("allowMultipleSites")]
    public bool? AllowMultipleSites { get; set; }

    [JsonPropertyName("customerStorageAccountArmId")]
    public string? CustomerStorageAccountArmId { get; set; }

    [JsonPropertyName("nestedSites")]
    public List<string>? NestedSites { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public MasterSitePropertiesPublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("sites")]
    public List<string>? Sites { get; set; }
}
