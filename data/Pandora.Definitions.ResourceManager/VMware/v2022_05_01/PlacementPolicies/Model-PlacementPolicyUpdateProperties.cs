using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PlacementPolicies;


internal class PlacementPolicyUpdatePropertiesModel
{
    [JsonPropertyName("affinityStrength")]
    public AffinityStrengthConstant? AffinityStrength { get; set; }

    [JsonPropertyName("azureHybridBenefitType")]
    public AzureHybridBenefitTypeConstant? AzureHybridBenefitType { get; set; }

    [JsonPropertyName("hostMembers")]
    public List<string>? HostMembers { get; set; }

    [JsonPropertyName("state")]
    public PlacementPolicyStateConstant? State { get; set; }

    [JsonPropertyName("vmMembers")]
    public List<string>? VMMembers { get; set; }
}
