using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OperationalizationClusters;


internal class AksNetworkingConfigurationModel
{
    [JsonPropertyName("dnsServiceIP")]
    public string? DnsServiceIP { get; set; }

    [JsonPropertyName("dockerBridgeCidr")]
    public string? DockerBridgeCidr { get; set; }

    [JsonPropertyName("serviceCidr")]
    public string? ServiceCidr { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }
}
