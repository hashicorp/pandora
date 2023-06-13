using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstanceAdministrators;


internal class ManagedInstanceAdministratorPropertiesModel
{
    [JsonPropertyName("administratorType")]
    [Required]
    public ManagedInstanceAdministratorTypeConstant AdministratorType { get; set; }

    [JsonPropertyName("login")]
    [Required]
    public string Login { get; set; }

    [JsonPropertyName("sid")]
    [Required]
    public string Sid { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
