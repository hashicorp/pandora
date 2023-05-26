using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25.GuestConfigurationAssignments;


internal class GuestConfigurationNavigationModel
{
    [JsonPropertyName("assignmentSource")]
    public string? AssignmentSource { get; set; }

    [JsonPropertyName("assignmentType")]
    public AssignmentTypeConstant? AssignmentType { get; set; }

    [JsonPropertyName("configurationParameter")]
    public List<ConfigurationParameterModel>? ConfigurationParameter { get; set; }

    [JsonPropertyName("configurationProtectedParameter")]
    public List<ConfigurationParameterModel>? ConfigurationProtectedParameter { get; set; }

    [JsonPropertyName("configurationSetting")]
    public ConfigurationSettingModel? ConfigurationSetting { get; set; }

    [JsonPropertyName("contentHash")]
    public string? ContentHash { get; set; }

    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    [JsonPropertyName("contentUri")]
    public string? ContentUri { get; set; }

    [JsonPropertyName("kind")]
    public KindConstant? Kind { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
