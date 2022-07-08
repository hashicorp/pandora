using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.ManagedPrivateEndpoints;


internal class ManagedPrivateEndpointPropertiesModel
{
    [JsonPropertyName("groupId")]
    [Required]
    public string GroupId { get; set; }

    [JsonPropertyName("privateLinkResourceId")]
    [Required]
    public string PrivateLinkResourceId { get; set; }

    [JsonPropertyName("privateLinkResourceRegion")]
    public string? PrivateLinkResourceRegion { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("requestMessage")]
    public string? RequestMessage { get; set; }
}
