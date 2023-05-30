using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_04_03.CommunicationsGateways;


internal class CommunicationsGatewayUpdateModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemAndUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
