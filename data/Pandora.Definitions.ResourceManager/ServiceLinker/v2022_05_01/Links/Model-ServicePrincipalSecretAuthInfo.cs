using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Links;

[ValueForType("servicePrincipalSecret")]
internal class ServicePrincipalSecretAuthInfoModel : AuthInfoBaseModel
{
    [JsonPropertyName("clientId")]
    [Required]
    public string ClientId { get; set; }

    [JsonPropertyName("principalId")]
    [Required]
    public string PrincipalId { get; set; }

    [JsonPropertyName("secret")]
    [Required]
    public string Secret { get; set; }
}
