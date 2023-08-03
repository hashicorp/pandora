using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2023_06_01.Accounts;


internal class CustomerManagedKeyEncryptionKeyEncryptionKeyIdentityModel
{
    [JsonPropertyName("delegatedIdentityClientId")]
    public string? DelegatedIdentityClientId { get; set; }

    [JsonPropertyName("identityType")]
    public IdentityTypeConstant? IdentityType { get; set; }

    [JsonPropertyName("userAssignedIdentityResourceId")]
    public string? UserAssignedIdentityResourceId { get; set; }
}
