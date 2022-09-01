using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService;


internal class CommunicationServicePropertiesModel
{
    [JsonPropertyName("dataLocation")]
    [Required]
    public string DataLocation { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("immutableResourceId")]
    public string? ImmutableResourceId { get; set; }

    [JsonPropertyName("notificationHubId")]
    public string? NotificationHubId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
