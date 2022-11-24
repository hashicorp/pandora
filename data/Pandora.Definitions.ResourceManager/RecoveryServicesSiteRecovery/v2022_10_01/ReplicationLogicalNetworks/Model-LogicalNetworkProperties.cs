using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationLogicalNetworks;


internal class LogicalNetworkPropertiesModel
{
    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("logicalNetworkDefinitionsStatus")]
    public string? LogicalNetworkDefinitionsStatus { get; set; }

    [JsonPropertyName("logicalNetworkUsage")]
    public string? LogicalNetworkUsage { get; set; }

    [JsonPropertyName("networkVirtualizationStatus")]
    public string? NetworkVirtualizationStatus { get; set; }
}
