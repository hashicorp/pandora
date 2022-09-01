using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;


internal class BackendModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("backendHostHeader")]
    public string? BackendHostHeader { get; set; }

    [JsonPropertyName("enabledState")]
    public BackendEnabledStateConstant? EnabledState { get; set; }

    [JsonPropertyName("httpPort")]
    public int? HTTPPort { get; set; }

    [JsonPropertyName("httpsPort")]
    public int? HTTPSPort { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("privateEndpointStatus")]
    public PrivateEndpointStatusConstant? PrivateEndpointStatus { get; set; }

    [JsonPropertyName("privateLinkAlias")]
    public string? PrivateLinkAlias { get; set; }

    [JsonPropertyName("privateLinkApprovalMessage")]
    public string? PrivateLinkApprovalMessage { get; set; }

    [JsonPropertyName("privateLinkLocation")]
    public string? PrivateLinkLocation { get; set; }

    [JsonPropertyName("privateLinkResourceId")]
    public string? PrivateLinkResourceId { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
