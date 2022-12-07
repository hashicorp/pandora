using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.ArcSettings;


internal class ArcIdentityResponsePropertiesModel
{
    [JsonPropertyName("arcApplicationClientId")]
    public string? ArcApplicationClientId { get; set; }

    [JsonPropertyName("arcApplicationObjectId")]
    public string? ArcApplicationObjectId { get; set; }

    [JsonPropertyName("arcApplicationTenantId")]
    public string? ArcApplicationTenantId { get; set; }

    [JsonPropertyName("arcServicePrincipalObjectId")]
    public string? ArcServicePrincipalObjectId { get; set; }
}
