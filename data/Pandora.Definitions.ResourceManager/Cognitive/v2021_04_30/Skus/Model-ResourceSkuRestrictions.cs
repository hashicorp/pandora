using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.Skus;


internal class ResourceSkuRestrictionsModel
{
    [JsonPropertyName("reasonCode")]
    public ResourceSkuRestrictionsReasonCodeConstant? ReasonCode { get; set; }

    [JsonPropertyName("restrictionInfo")]
    public ResourceSkuRestrictionInfoModel? RestrictionInfo { get; set; }

    [JsonPropertyName("type")]
    public ResourceSkuRestrictionsTypeConstant? Type { get; set; }

    [JsonPropertyName("values")]
    public List<string>? Values { get; set; }
}
