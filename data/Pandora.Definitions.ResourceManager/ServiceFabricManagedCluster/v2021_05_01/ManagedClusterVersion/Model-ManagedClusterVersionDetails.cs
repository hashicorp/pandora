using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedClusterVersion;


internal class ManagedClusterVersionDetailsModel
{
    [JsonPropertyName("clusterCodeVersion")]
    public string? ClusterCodeVersion { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("supportExpiryUtc")]
    public string? SupportExpiryUtc { get; set; }
}
