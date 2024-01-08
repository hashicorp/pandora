using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.FetchTieringCost;

[ValueForType("TieringCostRehydrationInfo")]
internal class TieringCostRehydrationInfoModel : TieringCostInfoModel
{
    [JsonPropertyName("rehydrationSizeInBytes")]
    [Required]
    public int RehydrationSizeInBytes { get; set; }

    [JsonPropertyName("retailRehydrationCostPerGBPerMonth")]
    [Required]
    public float RetailRehydrationCostPerGBPerMonth { get; set; }
}
