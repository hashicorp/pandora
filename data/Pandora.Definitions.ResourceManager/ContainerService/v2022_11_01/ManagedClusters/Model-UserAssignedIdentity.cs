using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;


internal class UserAssignedIdentityModel
{
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }
}
