using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class ApiKVReferencePropertiesModel
{
    [JsonPropertyName("activeVersion")]
    public string? ActiveVersion { get; set; }

    [JsonPropertyName("details")]
    public string? Details { get; set; }

    [JsonPropertyName("identityType")]
    public CustomTypes.SystemAndUserAssignedIdentityMap? IdentityType { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("secretName")]
    public string? SecretName { get; set; }

    [JsonPropertyName("secretVersion")]
    public string? SecretVersion { get; set; }

    [JsonPropertyName("source")]
    public ConfigReferenceSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public ResolveStatusConstant? Status { get; set; }

    [JsonPropertyName("vaultName")]
    public string? VaultName { get; set; }
}
