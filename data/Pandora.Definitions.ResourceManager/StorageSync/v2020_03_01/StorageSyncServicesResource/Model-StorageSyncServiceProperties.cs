using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.StorageSyncServicesResource;


internal class StorageSyncServicePropertiesModel
{
    [JsonPropertyName("incomingTrafficPolicy")]
    public IncomingTrafficPolicyConstant? IncomingTrafficPolicy { get; set; }

    [JsonPropertyName("lastOperationName")]
    public string? LastOperationName { get; set; }

    [JsonPropertyName("lastWorkflowId")]
    public string? LastWorkflowId { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("storageSyncServiceStatus")]
    public int? StorageSyncServiceStatus { get; set; }

    [JsonPropertyName("storageSyncServiceUid")]
    public string? StorageSyncServiceUid { get; set; }
}
