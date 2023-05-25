using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.Databases;


internal class DatabaseIdentityModel
{
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("type")]
    public DatabaseIdentityTypeConstant? Type { get; set; }

    [JsonPropertyName("userAssignedIdentities")]
    public Dictionary<string, DatabaseUserIdentityModel>? UserAssignedIdentities { get; set; }
}
