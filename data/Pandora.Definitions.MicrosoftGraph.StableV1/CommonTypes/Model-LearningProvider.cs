// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class LearningProviderModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isCourseActivitySyncEnabled")]
    public bool? IsCourseActivitySyncEnabled { get; set; }

    [JsonPropertyName("learningContents")]
    public List<LearningContentModel>? LearningContents { get; set; }

    [JsonPropertyName("learningCourseActivities")]
    public List<LearningCourseActivityModel>? LearningCourseActivities { get; set; }

    [JsonPropertyName("loginWebUrl")]
    public string? LoginWebUrl { get; set; }

    [JsonPropertyName("longLogoWebUrlForDarkTheme")]
    public string? LongLogoWebUrlForDarkTheme { get; set; }

    [JsonPropertyName("longLogoWebUrlForLightTheme")]
    public string? LongLogoWebUrlForLightTheme { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("squareLogoWebUrlForDarkTheme")]
    public string? SquareLogoWebUrlForDarkTheme { get; set; }

    [JsonPropertyName("squareLogoWebUrlForLightTheme")]
    public string? SquareLogoWebUrlForLightTheme { get; set; }
}
