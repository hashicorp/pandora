using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SecurityMLAnalyticsSettings;


internal class AnomalySecurityMLAnalyticsSettingsPropertiesModel
{
    [JsonPropertyName("anomalySettingsVersion")]
    public int? AnomalySettingsVersion { get; set; }

    [JsonPropertyName("anomalyVersion")]
    [Required]
    public string AnomalyVersion { get; set; }

    [JsonPropertyName("customizableObservations")]
    public object? CustomizableObservations { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("frequency")]
    [Required]
    public string Frequency { get; set; }

    [JsonPropertyName("isDefaultSettings")]
    [Required]
    public bool IsDefaultSettings { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedUtc")]
    public DateTime? LastModifiedUtc { get; set; }

    [JsonPropertyName("requiredDataConnectors")]
    public List<SecurityMLAnalyticsSettingsDataSourceModel>? RequiredDataConnectors { get; set; }

    [JsonPropertyName("settingsDefinitionId")]
    public string? SettingsDefinitionId { get; set; }

    [JsonPropertyName("settingsStatus")]
    [Required]
    public SettingsStatusConstant SettingsStatus { get; set; }

    [JsonPropertyName("tactics")]
    public List<AttackTacticConstant>? Tactics { get; set; }

    [JsonPropertyName("techniques")]
    public List<string>? Techniques { get; set; }
}
