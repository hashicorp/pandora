using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ServerAzureADAdministrators;


internal class AdministratorPropertiesModel
{
    [JsonPropertyName("administratorType")]
    [Required]
    public AdministratorTypeConstant AdministratorType { get; set; }

    [JsonPropertyName("azureADOnlyAuthentication")]
    public bool? AzureADOnlyAuthentication { get; set; }

    [JsonPropertyName("login")]
    [Required]
    public string Login { get; set; }

    [JsonPropertyName("sid")]
    [Required]
    public string Sid { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
