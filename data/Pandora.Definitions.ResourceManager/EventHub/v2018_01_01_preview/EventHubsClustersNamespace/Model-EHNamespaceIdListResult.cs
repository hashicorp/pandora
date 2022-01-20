using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersNamespace;


internal class EHNamespaceIdListResultModel
{
    [JsonPropertyName("value")]
    public List<EHNamespaceIdContainerModel>? Value { get; set; }
}
