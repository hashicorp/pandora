using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;


internal class RemotePrivateEndpointConnectionPropertiesModel
{
    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("privateEndpoint")]
    public ArmIdWrapperModel? PrivateEndpoint { get; set; }

    [JsonPropertyName("privateLinkServiceConnectionState")]
    public PrivateLinkConnectionStateModel? PrivateLinkServiceConnectionState { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
