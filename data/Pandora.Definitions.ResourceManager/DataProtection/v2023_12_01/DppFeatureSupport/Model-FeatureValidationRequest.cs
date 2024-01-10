using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.DppFeatureSupport;

[ValueForType("FeatureValidationRequest")]
internal class FeatureValidationRequestModel : FeatureValidationRequestBaseModel
{
    [JsonPropertyName("featureName")]
    public string? FeatureName { get; set; }

    [JsonPropertyName("featureType")]
    public FeatureTypeConstant? FeatureType { get; set; }
}
