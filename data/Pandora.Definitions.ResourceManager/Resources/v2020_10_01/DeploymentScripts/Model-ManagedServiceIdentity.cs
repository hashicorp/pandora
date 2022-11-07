using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.DeploymentScripts;


internal class ManagedServiceIdentityModel
{
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("type")]
    public ManagedServiceIdentityTypeConstant? Type { get; set; }

    [JsonPropertyName("userAssignedIdentities")]
    public Dictionary<string, UserAssignedIdentityModel>? UserAssignedIdentities { get; set; }
}
