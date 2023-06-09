using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;


internal class PlanDataModel
{
    [JsonPropertyName("billingCycle")]
    [Required]
    public BillingCycleConstant BillingCycle { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("effectiveDate")]
    public DateTime? EffectiveDate { get; set; }

    [JsonPropertyName("planId")]
    [Required]
    public string PlanId { get; set; }

    [JsonPropertyName("usageType")]
    public UsageTypeConstant? UsageType { get; set; }
}
