using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.ManagedNetwork;


internal class PrivateEndpointDestinationModel
{
    [JsonPropertyName("serviceResourceId")]
    public string? ServiceResourceId { get; set; }

    [JsonPropertyName("sparkEnabled")]
    public bool? SparkEnabled { get; set; }

    [JsonPropertyName("sparkStatus")]
    public RuleStatusConstant? SparkStatus { get; set; }

    [JsonPropertyName("subresourceTarget")]
    public string? SubresourceTarget { get; set; }
}
