using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataReference;

[ValueForType("ManagedIdentity")]
internal class ManagedIdentityCredentialModel : DataReferenceCredentialModel
{
    [JsonPropertyName("managedIdentityType")]
    public string? ManagedIdentityType { get; set; }

    [JsonPropertyName("userManagedIdentityClientId")]
    public string? UserManagedIdentityClientId { get; set; }

    [JsonPropertyName("userManagedIdentityPrincipalId")]
    public string? UserManagedIdentityPrincipalId { get; set; }

    [JsonPropertyName("userManagedIdentityResourceId")]
    public string? UserManagedIdentityResourceId { get; set; }

    [JsonPropertyName("userManagedIdentityTenantId")]
    public string? UserManagedIdentityTenantId { get; set; }
}
