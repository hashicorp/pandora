using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Costs;


internal class LabCostPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("labCostDetails")]
    public List<LabCostDetailsPropertiesModel>? LabCostDetails { get; set; }

    [JsonPropertyName("labCostSummary")]
    public LabCostSummaryPropertiesModel? LabCostSummary { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceCosts")]
    public List<LabResourceCostPropertiesModel>? ResourceCosts { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("targetCost")]
    public TargetCostPropertiesModel? TargetCost { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }
}
