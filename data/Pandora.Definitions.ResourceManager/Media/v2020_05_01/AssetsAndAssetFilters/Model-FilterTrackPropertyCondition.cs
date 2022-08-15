using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.AssetsAndAssetFilters;


internal class FilterTrackPropertyConditionModel
{
    [JsonPropertyName("operation")]
    [Required]
    public FilterTrackPropertyCompareOperationConstant Operation { get; set; }

    [JsonPropertyName("property")]
    [Required]
    public FilterTrackPropertyTypeConstant Property { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
