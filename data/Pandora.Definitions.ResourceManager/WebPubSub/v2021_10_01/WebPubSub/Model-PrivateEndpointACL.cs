using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.WebPubSub.v2021_10_01.WebPubSub;


internal class PrivateEndpointACLModel
{
    [JsonPropertyName("allow")]
    public List<WebPubSubRequestTypeConstant>? Allow { get; set; }

    [JsonPropertyName("deny")]
    public List<WebPubSubRequestTypeConstant>? Deny { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
