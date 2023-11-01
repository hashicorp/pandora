using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.FetchTieringCost;

[ValueForType("TieringCostSavingInfo")]
internal class TieringCostSavingInfoModel : TieringCostInfoModel
{
    [JsonPropertyName("retailSourceTierCostPerGBPerMonth")]
    [Required]
    public float RetailSourceTierCostPerGBPerMonth { get; set; }

    [JsonPropertyName("retailTargetTierCostPerGBPerMonth")]
    [Required]
    public float RetailTargetTierCostPerGBPerMonth { get; set; }

    [JsonPropertyName("sourceTierSizeReductionInBytes")]
    [Required]
    public int SourceTierSizeReductionInBytes { get; set; }

    [JsonPropertyName("targetTierSizeIncreaseInBytes")]
    [Required]
    public int TargetTierSizeIncreaseInBytes { get; set; }
}
