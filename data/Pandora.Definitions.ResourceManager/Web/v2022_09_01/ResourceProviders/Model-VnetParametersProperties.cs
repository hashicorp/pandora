using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;


internal class VnetParametersPropertiesModel
{
    [JsonPropertyName("subnetResourceId")]
    public string? SubnetResourceId { get; set; }

    [JsonPropertyName("vnetName")]
    public string? VnetName { get; set; }

    [JsonPropertyName("vnetResourceGroup")]
    public string? VnetResourceGroup { get; set; }

    [JsonPropertyName("vnetSubnetName")]
    public string? VnetSubnetName { get; set; }
}
