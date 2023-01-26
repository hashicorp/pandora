using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Application;


internal class ArmApplicationHealthPolicyModel
{
    [JsonPropertyName("considerWarningAsError")]
    public bool? ConsiderWarningAsError { get; set; }

    [JsonPropertyName("defaultServiceTypeHealthPolicy")]
    public ArmServiceTypeHealthPolicyModel? DefaultServiceTypeHealthPolicy { get; set; }

    [JsonPropertyName("maxPercentUnhealthyDeployedApplications")]
    public int? MaxPercentUnhealthyDeployedApplications { get; set; }

    [JsonPropertyName("serviceTypeHealthPolicyMap")]
    public Dictionary<string, ArmServiceTypeHealthPolicyModel>? ServiceTypeHealthPolicyMap { get; set; }
}
