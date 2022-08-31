using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Clusters;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("capacityAllocated")]
    public int? CapacityAllocated { get; set; }

    [JsonPropertyName("capacityAssigned")]
    public int? CapacityAssigned { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("provisioningState")]
    public ClusterProvisioningStateConstant? ProvisioningState { get; set; }
}
