using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType
{

    internal class NodeTypeActionParametersModel
    {
        [JsonPropertyName("force")]
        public bool? Force { get; set; }

        [JsonPropertyName("nodes")]
        [Required]
        public List<string> Nodes { get; set; }
    }
}
