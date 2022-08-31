using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.MaintenanceConfigurations;


internal class MaintenanceConfigurationPropertiesModel
{
    [JsonPropertyName("extensionProperties")]
    public Dictionary<string, string>? ExtensionProperties { get; set; }

    [JsonPropertyName("maintenanceScope")]
    public MaintenanceScopeConstant? MaintenanceScope { get; set; }

    [JsonPropertyName("maintenanceWindow")]
    public MaintenanceWindowModel? MaintenanceWindow { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("visibility")]
    public VisibilityConstant? Visibility { get; set; }
}
