using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentWorkItemConfigsAPIs;


internal class WorkItemCreateConfigurationModel
{
    [JsonPropertyName("ConnectorDataConfiguration")]
    public string? ConnectorDataConfiguration { get; set; }

    [JsonPropertyName("ConnectorId")]
    public string? ConnectorId { get; set; }

    [JsonPropertyName("ValidateOnly")]
    public bool? ValidateOnly { get; set; }

    [JsonPropertyName("WorkItemProperties")]
    public Dictionary<string, string>? WorkItemProperties { get; set; }
}
