using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Vaults;


internal class AccessPolicyEntryModel
{
    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("objectId")]
    [Required]
    public string ObjectId { get; set; }

    [JsonPropertyName("permissions")]
    [Required]
    public PermissionsModel Permissions { get; set; }

    [JsonPropertyName("tenantId")]
    [Required]
    public string TenantId { get; set; }
}
