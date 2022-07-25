using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.Clusters;


internal class VirtualNetworkConfigurationModel
{
    [JsonPropertyName("dataManagementPublicIpId")]
    [Required]
    public string DataManagementPublicIpId { get; set; }

    [JsonPropertyName("enginePublicIpId")]
    [Required]
    public string EnginePublicIpId { get; set; }

    [JsonPropertyName("subnetId")]
    [Required]
    public string SubnetId { get; set; }
}
