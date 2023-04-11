using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.AllowedConnections;


internal class ConnectableResourceModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inboundConnectedResources")]
    public List<ConnectedResourceModel>? InboundConnectedResources { get; set; }

    [JsonPropertyName("outboundConnectedResources")]
    public List<ConnectedResourceModel>? OutboundConnectedResources { get; set; }
}
