using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_01_01.ActionGroupsAPIs;


internal class ItsmReceiverModel
{
    [JsonPropertyName("connectionId")]
    [Required]
    public string ConnectionId { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("region")]
    [Required]
    public string Region { get; set; }

    [JsonPropertyName("ticketConfiguration")]
    [Required]
    public string TicketConfiguration { get; set; }

    [JsonPropertyName("workspaceId")]
    [Required]
    public string WorkspaceId { get; set; }
}
