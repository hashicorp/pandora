using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;


internal class AcceleratorGitRepositoryModel
{
    [JsonPropertyName("authSetting")]
    [Required]
    public AcceleratorAuthSettingModel AuthSetting { get; set; }

    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("commit")]
    public string? Commit { get; set; }

    [JsonPropertyName("gitTag")]
    public string? GitTag { get; set; }

    [JsonPropertyName("intervalInSeconds")]
    public int? IntervalInSeconds { get; set; }

    [JsonPropertyName("url")]
    [Required]
    public string Url { get; set; }
}
