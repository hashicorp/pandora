using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.ConnectedRegistries;


internal class ConnectedRegistryPropertiesModel
{
    [JsonPropertyName("activation")]
    public ActivationPropertiesModel? Activation { get; set; }

    [JsonPropertyName("clientTokenIds")]
    public List<string>? ClientTokenIds { get; set; }

    [JsonPropertyName("connectionState")]
    public ConnectionStateConstant? ConnectionState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastActivityTime")]
    public DateTime? LastActivityTime { get; set; }

    [JsonPropertyName("logging")]
    public LoggingPropertiesModel? Logging { get; set; }

    [JsonPropertyName("loginServer")]
    public LoginServerPropertiesModel? LoginServer { get; set; }

    [JsonPropertyName("mode")]
    [Required]
    public ConnectedRegistryModeConstant Mode { get; set; }

    [JsonPropertyName("notificationsList")]
    public List<string>? NotificationsList { get; set; }

    [JsonPropertyName("parent")]
    [Required]
    public ParentPropertiesModel Parent { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("statusDetails")]
    public List<StatusDetailPropertiesModel>? StatusDetails { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
