using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.BenefitUtilizationSummariesAsync;


internal class BenefitUtilizationSummariesRequestModel
{
    [JsonPropertyName("benefitId")]
    public string? BenefitId { get; set; }

    [JsonPropertyName("benefitOrderId")]
    public string? BenefitOrderId { get; set; }

    [JsonPropertyName("billingAccountId")]
    public string? BillingAccountId { get; set; }

    [JsonPropertyName("billingProfileId")]
    public string? BillingProfileId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endDate")]
    [Required]
    public DateTime EndDate { get; set; }

    [JsonPropertyName("grain")]
    [Required]
    public GrainConstant Grain { get; set; }

    [JsonPropertyName("kind")]
    public BenefitKindConstant? Kind { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDate")]
    [Required]
    public DateTime StartDate { get; set; }
}
