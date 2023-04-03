using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRules;

[ValueForType("Microsoft.Azure.Management.Insights.Models.RuleManagementEventDataSource")]
internal class RuleManagementEventDataSourceModel : RuleDataSourceModel
{
    [JsonPropertyName("claims")]
    public RuleManagementEventClaimsDataSourceModel? Claims { get; set; }

    [JsonPropertyName("eventName")]
    public string? EventName { get; set; }

    [JsonPropertyName("eventSource")]
    public string? EventSource { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("operationName")]
    public string? OperationName { get; set; }

    [JsonPropertyName("resourceGroupName")]
    public string? ResourceGroupName { get; set; }

    [JsonPropertyName("resourceProviderName")]
    public string? ResourceProviderName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("subStatus")]
    public string? SubStatus { get; set; }
}
