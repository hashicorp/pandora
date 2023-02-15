using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_01_01.ActionGroupsAPIs;


internal class ActionGroupModel
{
    [JsonPropertyName("armRoleReceivers")]
    public List<ArmRoleReceiverModel>? ArmRoleReceivers { get; set; }

    [JsonPropertyName("automationRunbookReceivers")]
    public List<AutomationRunbookReceiverModel>? AutomationRunbookReceivers { get; set; }

    [JsonPropertyName("azureAppPushReceivers")]
    public List<AzureAppPushReceiverModel>? AzureAppPushReceivers { get; set; }

    [JsonPropertyName("azureFunctionReceivers")]
    public List<AzureFunctionReceiverModel>? AzureFunctionReceivers { get; set; }

    [JsonPropertyName("emailReceivers")]
    public List<EmailReceiverModel>? EmailReceivers { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("eventHubReceivers")]
    public List<EventHubReceiverModel>? EventHubReceivers { get; set; }

    [JsonPropertyName("groupShortName")]
    [Required]
    public string GroupShortName { get; set; }

    [JsonPropertyName("itsmReceivers")]
    public List<ItsmReceiverModel>? ItsmReceivers { get; set; }

    [JsonPropertyName("logicAppReceivers")]
    public List<LogicAppReceiverModel>? LogicAppReceivers { get; set; }

    [JsonPropertyName("smsReceivers")]
    public List<SmsReceiverModel>? SmsReceivers { get; set; }

    [JsonPropertyName("voiceReceivers")]
    public List<VoiceReceiverModel>? VoiceReceivers { get; set; }

    [JsonPropertyName("webhookReceivers")]
    public List<WebhookReceiverModel>? WebhookReceivers { get; set; }
}
