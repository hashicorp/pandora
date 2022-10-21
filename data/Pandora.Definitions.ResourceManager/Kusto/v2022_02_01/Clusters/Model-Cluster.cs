using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.Clusters;


internal class ClusterModel
{
    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identity")]
    public CustomTypes.SystemAndUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("location")]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("properties")]
    public ClusterPropertiesModel? Properties { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public AzureSkuModel Sku { get; set; }

    [JsonPropertyName("systemData")]
    public CustomTypes.SystemData? SystemData { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("zones")]
    public List<string>? Zones { get; set; }
}
