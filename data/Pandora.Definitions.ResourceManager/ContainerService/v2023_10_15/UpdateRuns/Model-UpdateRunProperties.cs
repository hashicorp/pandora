using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.UpdateRuns;


internal class UpdateRunPropertiesModel
{
    [JsonPropertyName("managedClusterUpdate")]
    [Required]
    public ManagedClusterUpdateModel ManagedClusterUpdate { get; set; }

    [JsonPropertyName("provisioningState")]
    public UpdateRunProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public UpdateRunStatusModel? Status { get; set; }

    [JsonPropertyName("strategy")]
    public UpdateRunStrategyModel? Strategy { get; set; }

    [JsonPropertyName("updateStrategyId")]
    public string? UpdateStrategyId { get; set; }
}
