using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.FleetUpdateStrategies;


internal class FleetUpdateStrategyPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public FleetUpdateStrategyProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("strategy")]
    [Required]
    public UpdateRunStrategyModel Strategy { get; set; }
}
