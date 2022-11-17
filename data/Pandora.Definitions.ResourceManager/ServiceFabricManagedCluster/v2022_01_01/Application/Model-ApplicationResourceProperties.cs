using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Application;


internal class ApplicationResourcePropertiesModel
{
    [JsonPropertyName("managedIdentities")]
    public List<ApplicationUserAssignedIdentityModel>? ManagedIdentities { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("upgradePolicy")]
    public ApplicationUpgradePolicyModel? UpgradePolicy { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
