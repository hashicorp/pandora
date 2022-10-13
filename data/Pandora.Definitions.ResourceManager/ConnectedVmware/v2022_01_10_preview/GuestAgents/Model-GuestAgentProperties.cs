using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.GuestAgents;


internal class GuestAgentPropertiesModel
{
    [JsonPropertyName("credentials")]
    public GuestCredentialModel? Credentials { get; set; }

    [JsonPropertyName("customResourceName")]
    public string? CustomResourceName { get; set; }

    [JsonPropertyName("httpProxyConfig")]
    public HTTPProxyConfigurationModel? HTTPProxyConfig { get; set; }

    [JsonPropertyName("provisioningAction")]
    public ProvisioningActionConstant? ProvisioningAction { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("statuses")]
    public List<ResourceStatusModel>? Statuses { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
}
