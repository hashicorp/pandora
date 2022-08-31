using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.StreamingPoliciesAndStreamingLocators;


internal class TrackPropertyConditionModel
{
    [JsonPropertyName("operation")]
    [Required]
    public TrackPropertyCompareOperationConstant Operation { get; set; }

    [JsonPropertyName("property")]
    [Required]
    public TrackPropertyTypeConstant Property { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
