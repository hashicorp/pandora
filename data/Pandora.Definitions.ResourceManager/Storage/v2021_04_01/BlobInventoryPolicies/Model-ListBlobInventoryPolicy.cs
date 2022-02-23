using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobInventoryPolicies;


internal class ListBlobInventoryPolicyModel
{
    [JsonPropertyName("value")]
    public List<BlobInventoryPolicyModel>? Value { get; set; }
}
