using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.Applications;


internal class ManagedIdentityTokenModel
{
    [JsonPropertyName("accessToken")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("authorizationAudience")]
    public string? AuthorizationAudience { get; set; }

    [JsonPropertyName("expiresIn")]
    public string? ExpiresIn { get; set; }

    [JsonPropertyName("expiresOn")]
    public string? ExpiresOn { get; set; }

    [JsonPropertyName("notBefore")]
    public string? NotBefore { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("tokenType")]
    public string? TokenType { get; set; }
}
