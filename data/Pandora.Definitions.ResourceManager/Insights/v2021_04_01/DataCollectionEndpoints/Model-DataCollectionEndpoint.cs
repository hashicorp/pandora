using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionEndpoints;


internal class DataCollectionEndpointModel
{
    [JsonPropertyName("configurationAccess")]
    public ConfigurationAccessEndpointSpecModel? ConfigurationAccess { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("immutableId")]
    public string? ImmutableId { get; set; }

    [JsonPropertyName("logsIngestion")]
    public LogsIngestionEndpointSpecModel? LogsIngestion { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkRuleSetModel? NetworkAcls { get; set; }

    [JsonPropertyName("provisioningState")]
    public KnownDataCollectionEndpointProvisioningStateConstant? ProvisioningState { get; set; }
}
