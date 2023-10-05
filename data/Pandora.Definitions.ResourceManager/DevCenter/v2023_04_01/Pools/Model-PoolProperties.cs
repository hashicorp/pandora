using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Pools;


internal class PoolPropertiesModel
{
    [JsonPropertyName("devBoxDefinitionName")]
    [Required]
    public string DevBoxDefinitionName { get; set; }

    [JsonPropertyName("healthStatus")]
    public HealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("healthStatusDetails")]
    public List<HealthStatusDetailModel>? HealthStatusDetails { get; set; }

    [JsonPropertyName("licenseType")]
    [Required]
    public LicenseTypeConstant LicenseType { get; set; }

    [JsonPropertyName("localAdministrator")]
    [Required]
    public LocalAdminStatusConstant LocalAdministrator { get; set; }

    [JsonPropertyName("networkConnectionName")]
    [Required]
    public string NetworkConnectionName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("stopOnDisconnect")]
    public StopOnDisconnectConfigurationModel? StopOnDisconnect { get; set; }
}
