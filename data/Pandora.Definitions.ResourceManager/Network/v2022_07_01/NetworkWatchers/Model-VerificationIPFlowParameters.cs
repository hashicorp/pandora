using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;


internal class VerificationIPFlowParametersModel
{
    [JsonPropertyName("direction")]
    [Required]
    public DirectionConstant Direction { get; set; }

    [JsonPropertyName("localIPAddress")]
    [Required]
    public string LocalIPAddress { get; set; }

    [JsonPropertyName("localPort")]
    [Required]
    public string LocalPort { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public IPFlowProtocolConstant Protocol { get; set; }

    [JsonPropertyName("remoteIPAddress")]
    [Required]
    public string RemoteIPAddress { get; set; }

    [JsonPropertyName("remotePort")]
    [Required]
    public string RemotePort { get; set; }

    [JsonPropertyName("targetNicResourceId")]
    public string? TargetNicResourceId { get; set; }

    [JsonPropertyName("targetResourceId")]
    [Required]
    public string TargetResourceId { get; set; }
}
