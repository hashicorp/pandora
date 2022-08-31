using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab;


internal class LabNetworkProfileModel
{
    [JsonPropertyName("loadBalancerId")]
    public string? LoadBalancerId { get; set; }

    [JsonPropertyName("publicIpId")]
    public string? PublicIPId { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }
}
