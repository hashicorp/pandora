using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2023_03_01.PrometheusRuleGroups;


internal class PrometheusRuleModel
{
    [JsonPropertyName("actions")]
    public List<PrometheusRuleGroupActionModel>? Actions { get; set; }

    [JsonPropertyName("alert")]
    public string? Alert { get; set; }

    [JsonPropertyName("annotations")]
    public Dictionary<string, string>? Annotations { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("expression")]
    [Required]
    public string Expression { get; set; }

    [JsonPropertyName("for")]
    public string? For { get; set; }

    [JsonPropertyName("labels")]
    public Dictionary<string, string>? Labels { get; set; }

    [JsonPropertyName("record")]
    public string? Record { get; set; }

    [JsonPropertyName("resolveConfiguration")]
    public PrometheusRuleResolveConfigurationModel? ResolveConfiguration { get; set; }

    [JsonPropertyName("severity")]
    public int? Severity { get; set; }
}
