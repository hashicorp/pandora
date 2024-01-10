using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.FetchTieringCost;

[ValueForType("FetchTieringCostInfoForRehydrationRequest")]
internal class FetchTieringCostInfoForRehydrationRequestModel : FetchTieringCostInfoRequestModel
{
    [JsonPropertyName("containerName")]
    [Required]
    public string ContainerName { get; set; }

    [JsonPropertyName("protectedItemName")]
    [Required]
    public string ProtectedItemName { get; set; }

    [JsonPropertyName("recoveryPointId")]
    [Required]
    public string RecoveryPointId { get; set; }

    [JsonPropertyName("rehydrationPriority")]
    [Required]
    public RehydrationPriorityConstant RehydrationPriority { get; set; }
}
