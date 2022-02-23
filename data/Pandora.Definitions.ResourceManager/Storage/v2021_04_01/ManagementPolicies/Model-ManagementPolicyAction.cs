using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.ManagementPolicies;


internal class ManagementPolicyActionModel
{
    [JsonPropertyName("baseBlob")]
    public ManagementPolicyBaseBlobModel? BaseBlob { get; set; }

    [JsonPropertyName("snapshot")]
    public ManagementPolicySnapShotModel? Snapshot { get; set; }

    [JsonPropertyName("version")]
    public ManagementPolicyVersionModel? Version { get; set; }
}
