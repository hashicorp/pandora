using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2023_03_01.CheckPolicyRestrictions;


internal class PolicyEvaluationResultModel
{
    [JsonPropertyName("effectDetails")]
    public PolicyEffectDetailsModel? EffectDetails { get; set; }

    [JsonPropertyName("evaluationDetails")]
    public CheckRestrictionEvaluationDetailsModel? EvaluationDetails { get; set; }

    [JsonPropertyName("evaluationResult")]
    public string? EvaluationResult { get; set; }

    [JsonPropertyName("policyInfo")]
    public PolicyReferenceModel? PolicyInfo { get; set; }
}
