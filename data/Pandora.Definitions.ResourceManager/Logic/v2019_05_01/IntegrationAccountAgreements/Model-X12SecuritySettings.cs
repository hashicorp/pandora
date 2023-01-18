using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12SecuritySettingsModel
{
    [JsonPropertyName("authorizationQualifier")]
    [Required]
    public string AuthorizationQualifier { get; set; }

    [JsonPropertyName("authorizationValue")]
    public string? AuthorizationValue { get; set; }

    [JsonPropertyName("passwordValue")]
    public string? PasswordValue { get; set; }

    [JsonPropertyName("securityQualifier")]
    [Required]
    public string SecurityQualifier { get; set; }
}
