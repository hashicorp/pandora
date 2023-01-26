using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PrivateLinkServices;


internal class RouteTablePropertiesFormatModel
{
    [JsonPropertyName("disableBgpRoutePropagation")]
    public bool? DisableBgpRoutePropagation { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("routes")]
    public List<RouteModel>? Routes { get; set; }

    [JsonPropertyName("subnets")]
    public List<SubnetModel>? Subnets { get; set; }
}
