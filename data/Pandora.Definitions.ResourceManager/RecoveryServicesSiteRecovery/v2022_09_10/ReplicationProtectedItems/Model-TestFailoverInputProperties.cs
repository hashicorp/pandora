using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;


internal class TestFailoverInputPropertiesModel
{
    [JsonPropertyName("failoverDirection")]
    public string? FailoverDirection { get; set; }

    [JsonPropertyName("networkId")]
    public string? NetworkId { get; set; }

    [JsonPropertyName("networkType")]
    public string? NetworkType { get; set; }

    [JsonPropertyName("providerSpecificDetails")]
    public TestFailoverProviderSpecificInputModel? ProviderSpecificDetails { get; set; }
}
