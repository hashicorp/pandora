using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.Monitors;


internal class IdentityPropertiesModel
{
    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ManagedIdentityTypeConstant Type { get; set; }

    [JsonPropertyName("userAssignedIdentities")]
    public Dictionary<string, UserAssignedIdentityModel>? UserAssignedIdentities { get; set; }
}
