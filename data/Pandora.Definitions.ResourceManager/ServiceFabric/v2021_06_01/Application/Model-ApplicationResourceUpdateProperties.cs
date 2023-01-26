using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Application;


internal class ApplicationResourceUpdatePropertiesModel
{
    [JsonPropertyName("managedIdentities")]
    public List<ApplicationUserAssignedIdentityModel>? ManagedIdentities { get; set; }

    [JsonPropertyName("maximumNodes")]
    public int? MaximumNodes { get; set; }

    [JsonPropertyName("metrics")]
    public List<ApplicationMetricDescriptionModel>? Metrics { get; set; }

    [JsonPropertyName("minimumNodes")]
    public int? MinimumNodes { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("removeApplicationCapacity")]
    public bool? RemoveApplicationCapacity { get; set; }

    [JsonPropertyName("typeVersion")]
    public string? TypeVersion { get; set; }

    [JsonPropertyName("upgradePolicy")]
    public ApplicationUpgradePolicyModel? UpgradePolicy { get; set; }
}
