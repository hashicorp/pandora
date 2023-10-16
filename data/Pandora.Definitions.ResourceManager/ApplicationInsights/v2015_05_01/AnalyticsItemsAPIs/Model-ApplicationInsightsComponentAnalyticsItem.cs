using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.AnalyticsItemsAPIs;


internal class ApplicationInsightsComponentAnalyticsItemModel
{
    [JsonPropertyName("Content")]
    public string? Content { get; set; }

    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("Properties")]
    public ApplicationInsightsComponentAnalyticsItemPropertiesModel? Properties { get; set; }

    [JsonPropertyName("Scope")]
    public ItemScopeConstant? Scope { get; set; }

    [JsonPropertyName("TimeCreated")]
    public string? TimeCreated { get; set; }

    [JsonPropertyName("TimeModified")]
    public string? TimeModified { get; set; }

    [JsonPropertyName("Type")]
    public ItemTypeConstant? Type { get; set; }

    [JsonPropertyName("Version")]
    public string? Version { get; set; }
}
