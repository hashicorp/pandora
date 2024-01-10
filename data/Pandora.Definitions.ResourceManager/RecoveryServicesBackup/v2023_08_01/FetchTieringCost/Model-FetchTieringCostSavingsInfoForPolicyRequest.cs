using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.FetchTieringCost;

[ValueForType("FetchTieringCostSavingsInfoForPolicyRequest")]
internal class FetchTieringCostSavingsInfoForPolicyRequestModel : FetchTieringCostInfoRequestModel
{
    [JsonPropertyName("policyName")]
    [Required]
    public string PolicyName { get; set; }
}
