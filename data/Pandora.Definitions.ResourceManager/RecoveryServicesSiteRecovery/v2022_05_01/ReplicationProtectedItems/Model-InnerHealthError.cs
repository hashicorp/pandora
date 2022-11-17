using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;


internal class InnerHealthErrorModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTimeUtc")]
    public DateTime? CreationTimeUtc { get; set; }

    [JsonPropertyName("customerResolvability")]
    public HealthErrorCustomerResolvabilityConstant? CustomerResolvability { get; set; }

    [JsonPropertyName("entityId")]
    public string? EntityId { get; set; }

    [JsonPropertyName("errorCategory")]
    public string? ErrorCategory { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorId")]
    public string? ErrorId { get; set; }

    [JsonPropertyName("errorLevel")]
    public string? ErrorLevel { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("errorSource")]
    public string? ErrorSource { get; set; }

    [JsonPropertyName("errorType")]
    public string? ErrorType { get; set; }

    [JsonPropertyName("possibleCauses")]
    public string? PossibleCauses { get; set; }

    [JsonPropertyName("recommendedAction")]
    public string? RecommendedAction { get; set; }

    [JsonPropertyName("recoveryProviderErrorMessage")]
    public string? RecoveryProviderErrorMessage { get; set; }

    [JsonPropertyName("summaryMessage")]
    public string? SummaryMessage { get; set; }
}
