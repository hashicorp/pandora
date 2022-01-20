using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets;


internal class IscsiTargetCreatePropertiesModel
{
    [JsonPropertyName("aclMode")]
    [Required]
    public IscsiTargetAclModeConstant AclMode { get; set; }

    [JsonPropertyName("luns")]
    public List<IscsiLunModel>? Luns { get; set; }

    [JsonPropertyName("staticAcls")]
    public List<AclModel>? StaticAcls { get; set; }

    [JsonPropertyName("targetIqn")]
    public string? TargetIqn { get; set; }
}
