using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;


internal class BillingResponseListResultModel
{
    [JsonPropertyName("billingResources")]
    public List<BillingResourcesModel>? BillingResources { get; set; }

    [JsonPropertyName("vmSizeFilters")]
    public List<VMSizeCompatibilityFilterV2Model>? VMSizeFilters { get; set; }

    [JsonPropertyName("vmSizeProperties")]
    public List<VMSizePropertyModel>? VMSizeProperties { get; set; }

    [JsonPropertyName("vmSizes")]
    public List<string>? VMSizes { get; set; }

    [JsonPropertyName("vmSizesWithEncryptionAtHost")]
    public List<string>? VMSizesWithEncryptionAtHost { get; set; }
}
