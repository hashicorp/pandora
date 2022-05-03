using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClustersAvailableClusterRegions;


internal class AvailableClustersListModel
{
    [JsonPropertyName("value")]
    public List<AvailableClusterModel>? Value { get; set; }
}
