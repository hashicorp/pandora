using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class ServiceTypeDeltaHealthPolicyModel
{
    [JsonPropertyName("maxPercentDeltaUnhealthyServices")]
    public int? MaxPercentDeltaUnhealthyServices { get; set; }
}
