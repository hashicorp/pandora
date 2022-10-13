using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;


internal class GuestAgentProfileModel
{
    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<ErrorDetailModel>? ErrorDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStatusChange")]
    public DateTime? LastStatusChange { get; set; }

    [JsonPropertyName("status")]
    public StatusTypesConstant? Status { get; set; }

    [JsonPropertyName("vmUuid")]
    public string? VmUuid { get; set; }
}
