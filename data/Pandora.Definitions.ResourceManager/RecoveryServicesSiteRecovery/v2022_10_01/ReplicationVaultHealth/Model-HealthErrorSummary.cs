using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationVaultHealth;


internal class HealthErrorSummaryModel
{
    [JsonPropertyName("affectedResourceCorrelationIds")]
    public List<string>? AffectedResourceCorrelationIds { get; set; }

    [JsonPropertyName("affectedResourceSubtype")]
    public string? AffectedResourceSubtype { get; set; }

    [JsonPropertyName("affectedResourceType")]
    public string? AffectedResourceType { get; set; }

    [JsonPropertyName("category")]
    public HealthErrorCategoryConstant? Category { get; set; }

    [JsonPropertyName("severity")]
    public SeverityConstant? Severity { get; set; }

    [JsonPropertyName("summaryCode")]
    public string? SummaryCode { get; set; }

    [JsonPropertyName("summaryMessage")]
    public string? SummaryMessage { get; set; }
}
