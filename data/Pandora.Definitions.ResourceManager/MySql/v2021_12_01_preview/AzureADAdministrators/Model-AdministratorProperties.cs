using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.AzureADAdministrators;


internal class AdministratorPropertiesModel
{
    [JsonPropertyName("administratorType")]
    public AdministratorTypeConstant? AdministratorType { get; set; }

    [JsonPropertyName("identityResourceId")]
    public string? IdentityResourceId { get; set; }

    [JsonPropertyName("login")]
    public string? Login { get; set; }

    [JsonPropertyName("sid")]
    public string? Sid { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
