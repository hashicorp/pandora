using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ManagedPrivateEndpoints;


internal class ManagedPrivateEndpointModel
{
    [JsonPropertyName("connectionState")]
    public ConnectionStatePropertiesModel? ConnectionState { get; set; }

    [JsonPropertyName("fqdns")]
    public List<string>? Fqdns { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("isReserved")]
    public bool? IsReserved { get; set; }

    [JsonPropertyName("privateLinkResourceId")]
    public string? PrivateLinkResourceId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
