using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.StreamingJobs;


internal class RefreshConfigurationModel
{
    [JsonPropertyName("dateFormat")]
    public string? DateFormat { get; set; }

    [JsonPropertyName("pathPattern")]
    public string? PathPattern { get; set; }

    [JsonPropertyName("refreshInterval")]
    public string? RefreshInterval { get; set; }

    [JsonPropertyName("refreshType")]
    public UpdatableUdfRefreshTypeConstant? RefreshType { get; set; }

    [JsonPropertyName("timeFormat")]
    public string? TimeFormat { get; set; }
}
