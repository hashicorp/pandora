using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_10_01.Agents;


internal class AgentPropertiesModel
{
    [JsonPropertyName("agentStatus")]
    public AgentStatusConstant? AgentStatus { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("arcResourceId")]
    [Required]
    public string ArcResourceId { get; set; }

    [JsonPropertyName("arcVmUuid")]
    [Required]
    public string ArcVMUuid { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("errorDetails")]
    public AgentPropertiesErrorDetailsModel? ErrorDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStatusUpdate")]
    public DateTime? LastStatusUpdate { get; set; }

    [JsonPropertyName("localIPAddress")]
    public string? LocalIPAddress { get; set; }

    [JsonPropertyName("memoryInMB")]
    public int? MemoryInMB { get; set; }

    [JsonPropertyName("numberOfCores")]
    public int? NumberOfCores { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("uptimeInSeconds")]
    public int? UptimeInSeconds { get; set; }
}
