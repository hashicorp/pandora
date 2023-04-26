using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.NetworkVirtualAppliances;


internal class PartnerManagedResourcePropertiesModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("internalLoadBalancerId")]
    public string? InternalLoadBalancerId { get; set; }

    [JsonPropertyName("standardLoadBalancerId")]
    public string? StandardLoadBalancerId { get; set; }
}
