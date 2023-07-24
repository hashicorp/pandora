using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class RampUpRuleModel
{
    [JsonPropertyName("actionHostName")]
    public string? ActionHostName { get; set; }

    [JsonPropertyName("changeDecisionCallbackUrl")]
    public string? ChangeDecisionCallbackUrl { get; set; }

    [JsonPropertyName("changeIntervalInMinutes")]
    public int? ChangeIntervalInMinutes { get; set; }

    [JsonPropertyName("changeStep")]
    public float? ChangeStep { get; set; }

    [JsonPropertyName("maxReroutePercentage")]
    public float? MaxReroutePercentage { get; set; }

    [JsonPropertyName("minReroutePercentage")]
    public float? MinReroutePercentage { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reroutePercentage")]
    public float? ReroutePercentage { get; set; }
}
