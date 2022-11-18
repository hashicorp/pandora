using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.Services;


internal class ServiceLoadMetricModel
{
    [JsonPropertyName("defaultLoad")]
    public int? DefaultLoad { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("primaryDefaultLoad")]
    public int? PrimaryDefaultLoad { get; set; }

    [JsonPropertyName("secondaryDefaultLoad")]
    public int? SecondaryDefaultLoad { get; set; }

    [JsonPropertyName("weight")]
    public ServiceLoadMetricWeightConstant? Weight { get; set; }
}
