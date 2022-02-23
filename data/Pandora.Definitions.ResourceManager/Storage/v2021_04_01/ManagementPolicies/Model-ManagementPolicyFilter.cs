using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.ManagementPolicies;


internal class ManagementPolicyFilterModel
{
    [JsonPropertyName("blobIndexMatch")]
    public List<TagFilterModel>? BlobIndexMatch { get; set; }

    [JsonPropertyName("blobTypes")]
    [Required]
    public List<string> BlobTypes { get; set; }

    [JsonPropertyName("prefixMatch")]
    public List<string>? PrefixMatch { get; set; }
}
