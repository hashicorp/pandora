using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;


internal class BillingResourcesModel
{
    [JsonPropertyName("billingMeters")]
    public List<BillingMetersModel>? BillingMeters { get; set; }

    [JsonPropertyName("diskBillingMeters")]
    public List<DiskBillingMetersModel>? DiskBillingMeters { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }
}
