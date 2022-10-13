using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationEvents;

[ValueForType("A2A")]
internal class A2AEventDetailsModel : EventProviderSpecificDetailsModel
{
    [JsonPropertyName("fabricLocation")]
    public string? FabricLocation { get; set; }

    [JsonPropertyName("fabricName")]
    public string? FabricName { get; set; }

    [JsonPropertyName("fabricObjectId")]
    public string? FabricObjectId { get; set; }

    [JsonPropertyName("protectedItemName")]
    public string? ProtectedItemName { get; set; }

    [JsonPropertyName("remoteFabricLocation")]
    public string? RemoteFabricLocation { get; set; }

    [JsonPropertyName("remoteFabricName")]
    public string? RemoteFabricName { get; set; }
}
