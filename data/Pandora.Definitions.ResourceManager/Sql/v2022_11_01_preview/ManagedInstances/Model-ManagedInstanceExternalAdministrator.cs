using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedInstances;


internal class ManagedInstanceExternalAdministratorModel
{
    [JsonPropertyName("administratorType")]
    public AdministratorTypeConstant? AdministratorType { get; set; }

    [JsonPropertyName("azureADOnlyAuthentication")]
    public bool? AzureADOnlyAuthentication { get; set; }

    [JsonPropertyName("login")]
    public string? Login { get; set; }

    [JsonPropertyName("principalType")]
    public PrincipalTypeConstant? PrincipalType { get; set; }

    [JsonPropertyName("sid")]
    public string? Sid { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
