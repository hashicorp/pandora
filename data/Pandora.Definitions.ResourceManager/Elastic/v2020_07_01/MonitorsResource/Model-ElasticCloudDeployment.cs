using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;


internal class ElasticCloudDeploymentModel
{
    [JsonPropertyName("azureSubscriptionId")]
    public string? AzureSubscriptionId { get; set; }

    [JsonPropertyName("deploymentId")]
    public string? DeploymentId { get; set; }

    [JsonPropertyName("elasticsearchRegion")]
    public string? ElasticsearchRegion { get; set; }

    [JsonPropertyName("elasticsearchServiceUrl")]
    public string? ElasticsearchServiceUrl { get; set; }

    [JsonPropertyName("kibanaServiceUrl")]
    public string? KibanaServiceUrl { get; set; }

    [JsonPropertyName("kibanaSsoUrl")]
    public string? KibanaSsoUrl { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
