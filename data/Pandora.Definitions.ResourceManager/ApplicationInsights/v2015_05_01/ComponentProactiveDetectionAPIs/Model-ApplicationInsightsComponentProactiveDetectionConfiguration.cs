using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentProactiveDetectionAPIs;


internal class ApplicationInsightsComponentProactiveDetectionConfigurationModel
{
    [JsonPropertyName("CustomEmails")]
    public List<string>? CustomEmails { get; set; }

    [JsonPropertyName("Enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("LastUpdatedTime")]
    public string? LastUpdatedTime { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("RuleDefinitions")]
    public ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitionsModel? RuleDefinitions { get; set; }

    [JsonPropertyName("SendEmailsToSubscriptionOwners")]
    public bool? SendEmailsToSubscriptionOwners { get; set; }
}
