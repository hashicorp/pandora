using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationVaultHealth;


internal class VaultHealthPropertiesModel
{
    [JsonPropertyName("containersHealth")]
    public ResourceHealthSummaryModel? ContainersHealth { get; set; }

    [JsonPropertyName("fabricsHealth")]
    public ResourceHealthSummaryModel? FabricsHealth { get; set; }

    [JsonPropertyName("protectedItemsHealth")]
    public ResourceHealthSummaryModel? ProtectedItemsHealth { get; set; }

    [JsonPropertyName("vaultErrors")]
    public List<HealthErrorModel>? VaultErrors { get; set; }
}
