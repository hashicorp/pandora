using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;


internal abstract class DistributionConfigurationModel
{
    [JsonPropertyName("distributionType")]
    [ProvidesTypeHint]
    [Required]
    public DistributionTypeConstant DistributionType { get; set; }
}
