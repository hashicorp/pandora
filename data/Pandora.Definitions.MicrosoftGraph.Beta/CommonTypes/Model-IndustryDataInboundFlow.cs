// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IndustryDataInboundFlowModel
{
    [JsonPropertyName("dataConnector")]
    public IndustryDataIndustryDataConnectorModel? DataConnector { get; set; }

    [JsonPropertyName("dataDomain")]
    public IndustryDataInboundFlowDataDomainConstant? DataDomain { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("effectiveDateTime")]
    public DateTime? EffectiveDateTime { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("readinessStatus")]
    public IndustryDataInboundFlowReadinessStatusConstant? ReadinessStatus { get; set; }

    [JsonPropertyName("year")]
    public IndustryDataYearTimePeriodDefinitionModel? Year { get; set; }
}
