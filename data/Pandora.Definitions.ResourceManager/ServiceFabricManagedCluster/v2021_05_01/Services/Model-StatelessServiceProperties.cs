using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Services;

[ValueForType("Stateless")]
internal class StatelessServicePropertiesModel : ServiceResourcePropertiesModel
{
    [JsonPropertyName("instanceCount")]
    [Required]
    public int InstanceCount { get; set; }

    [JsonPropertyName("minInstanceCount")]
    public int? MinInstanceCount { get; set; }

    [JsonPropertyName("minInstancePercentage")]
    public int? MinInstancePercentage { get; set; }
}
