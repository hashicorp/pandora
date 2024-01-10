using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.NetAppResource;


internal class NetworkSiblingSetModel
{
    [JsonPropertyName("networkFeatures")]
    public NetworkFeaturesConstant? NetworkFeatures { get; set; }

    [JsonPropertyName("networkSiblingSetId")]
    public string? NetworkSiblingSetId { get; set; }

    [JsonPropertyName("networkSiblingSetStateId")]
    public string? NetworkSiblingSetStateId { get; set; }

    [JsonPropertyName("nicInfoList")]
    public List<NicInfoModel>? NicInfoList { get; set; }

    [JsonPropertyName("provisioningState")]
    public NetworkSiblingSetProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }
}
