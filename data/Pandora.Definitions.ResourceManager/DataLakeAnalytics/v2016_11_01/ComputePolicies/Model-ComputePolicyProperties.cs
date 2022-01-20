using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.ComputePolicies;


internal class ComputePolicyPropertiesModel
{
    [JsonPropertyName("maxDegreeOfParallelismPerJob")]
    public int? MaxDegreeOfParallelismPerJob { get; set; }

    [JsonPropertyName("minPriorityPerJob")]
    public int? MinPriorityPerJob { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("objectType")]
    public AADObjectTypeConstant? ObjectType { get; set; }
}
