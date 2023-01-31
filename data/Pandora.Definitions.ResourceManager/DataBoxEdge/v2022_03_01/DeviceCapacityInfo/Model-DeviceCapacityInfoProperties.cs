using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DeviceCapacityInfo;


internal class DeviceCapacityInfoPropertiesModel
{
    [JsonPropertyName("clusterComputeCapacityInfo")]
    public ClusterCapacityViewDataModel? ClusterComputeCapacityInfo { get; set; }

    [JsonPropertyName("clusterStorageCapacityInfo")]
    public ClusterStorageViewDataModel? ClusterStorageCapacityInfo { get; set; }

    [JsonPropertyName("nodeCapacityInfos")]
    public Dictionary<string, HostCapacityModel>? NodeCapacityInfos { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeStamp")]
    public DateTime? TimeStamp { get; set; }
}
