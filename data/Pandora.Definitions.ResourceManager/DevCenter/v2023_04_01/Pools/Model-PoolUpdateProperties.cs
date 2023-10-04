using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Pools;


internal class PoolUpdatePropertiesModel
{
    [JsonPropertyName("devBoxDefinitionName")]
    public string? DevBoxDefinitionName { get; set; }

    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("localAdministrator")]
    public LocalAdminStatusConstant? LocalAdministrator { get; set; }

    [JsonPropertyName("networkConnectionName")]
    public string? NetworkConnectionName { get; set; }

    [JsonPropertyName("stopOnDisconnect")]
    public StopOnDisconnectConfigurationModel? StopOnDisconnect { get; set; }
}
