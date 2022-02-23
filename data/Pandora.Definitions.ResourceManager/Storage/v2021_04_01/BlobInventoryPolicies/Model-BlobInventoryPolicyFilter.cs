using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobInventoryPolicies;


internal class BlobInventoryPolicyFilterModel
{
    [JsonPropertyName("blobTypes")]
    public List<string>? BlobTypes { get; set; }

    [JsonPropertyName("includeBlobVersions")]
    public bool? IncludeBlobVersions { get; set; }

    [JsonPropertyName("includeSnapshots")]
    public bool? IncludeSnapshots { get; set; }

    [JsonPropertyName("prefixMatch")]
    public List<string>? PrefixMatch { get; set; }
}
