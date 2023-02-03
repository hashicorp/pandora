using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.Jobs;


internal class ErrorDetailsModel
{
    [JsonPropertyName("agentErrorCode")]
    public string? AgentErrorCode { get; set; }

    [JsonPropertyName("agentErrorMessage")]
    public string? AgentErrorMessage { get; set; }

    [JsonPropertyName("agentErrorPossibleCauses")]
    public string? AgentErrorPossibleCauses { get; set; }

    [JsonPropertyName("agentErrorRecommendedAction")]
    public string? AgentErrorRecommendedAction { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("isAgentReportedError")]
    public bool? IsAgentReportedError { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("possibleCauses")]
    public string? PossibleCauses { get; set; }

    [JsonPropertyName("recommendedAction")]
    public string? RecommendedAction { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }
}
