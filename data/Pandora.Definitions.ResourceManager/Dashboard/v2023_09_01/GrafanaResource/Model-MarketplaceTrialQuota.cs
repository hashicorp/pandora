using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dashboard.v2023_09_01.GrafanaResource;


internal class MarketplaceTrialQuotaModel
{
    [JsonPropertyName("availablePromotion")]
    public AvailablePromotionConstant? AvailablePromotion { get; set; }

    [JsonPropertyName("grafanaResourceId")]
    public string? GrafanaResourceId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("trialEndAt")]
    public DateTime? TrialEndAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("trialStartAt")]
    public DateTime? TrialStartAt { get; set; }
}
