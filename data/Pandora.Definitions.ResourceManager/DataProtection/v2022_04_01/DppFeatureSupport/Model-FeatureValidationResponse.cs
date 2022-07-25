using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.DppFeatureSupport;

[ValueForType("FeatureValidationResponse")]
internal class FeatureValidationResponseModel : FeatureValidationResponseBaseModel
{
    [JsonPropertyName("featureType")]
    public FeatureTypeConstant? FeatureType { get; set; }

    [JsonPropertyName("features")]
    public List<SupportedFeatureModel>? Features { get; set; }
}
