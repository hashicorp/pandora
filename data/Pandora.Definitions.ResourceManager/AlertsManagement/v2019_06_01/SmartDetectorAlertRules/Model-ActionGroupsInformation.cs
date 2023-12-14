using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_06_01.SmartDetectorAlertRules;


internal class ActionGroupsInformationModel
{
    [JsonPropertyName("customEmailSubject")]
    public string? CustomEmailSubject { get; set; }

    [JsonPropertyName("customWebhookPayload")]
    public string? CustomWebhookPayload { get; set; }

    [JsonPropertyName("groupIds")]
    [Required]
    public List<string> GroupIds { get; set; }
}
