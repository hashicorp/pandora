// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServicePlanInfoModel
{
    [JsonPropertyName("appliesTo")]
    public string? AppliesTo { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("provisioningStatus")]
    public string? ProvisioningStatus { get; set; }

    [JsonPropertyName("servicePlanId")]
    public string? ServicePlanId { get; set; }

    [JsonPropertyName("servicePlanName")]
    public string? ServicePlanName { get; set; }
}
