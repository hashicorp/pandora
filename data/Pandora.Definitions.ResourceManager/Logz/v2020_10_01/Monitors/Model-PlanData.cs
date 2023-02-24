using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.Monitors;


internal class PlanDataModel
{
    [JsonPropertyName("billingCycle")]
    public string? BillingCycle { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("effectiveDate")]
    public DateTime? EffectiveDate { get; set; }

    [JsonPropertyName("planDetails")]
    public string? PlanDetails { get; set; }

    [JsonPropertyName("usageType")]
    public string? UsageType { get; set; }
}
