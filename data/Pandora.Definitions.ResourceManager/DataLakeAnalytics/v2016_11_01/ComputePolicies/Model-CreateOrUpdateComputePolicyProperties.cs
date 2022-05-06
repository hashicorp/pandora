using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.ComputePolicies;


internal class CreateOrUpdateComputePolicyPropertiesModel
{
    [JsonPropertyName("maxDegreeOfParallelismPerJob")]
    public int? MaxDegreeOfParallelismPerJob { get; set; }

    [JsonPropertyName("minPriorityPerJob")]
    public int? MinPriorityPerJob { get; set; }

    [JsonPropertyName("objectId")]
    [Required]
    public string ObjectId { get; set; }

    [JsonPropertyName("objectType")]
    [Required]
    public AADObjectTypeConstant ObjectType { get; set; }
}
