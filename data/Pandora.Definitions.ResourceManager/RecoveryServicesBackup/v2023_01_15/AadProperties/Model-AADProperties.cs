using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.AadProperties;


internal class AADPropertiesModel
{
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    [JsonPropertyName("authority")]
    public string? Authority { get; set; }

    [JsonPropertyName("servicePrincipalClientId")]
    public string? ServicePrincipalClientId { get; set; }

    [JsonPropertyName("servicePrincipalObjectId")]
    public string? ServicePrincipalObjectId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
