using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsAuthConfigs;


internal class AzureActiveDirectoryRegistrationModel
{
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecretCertificateIssuer")]
    public string? ClientSecretCertificateIssuer { get; set; }

    [JsonPropertyName("clientSecretCertificateSubjectAlternativeName")]
    public string? ClientSecretCertificateSubjectAlternativeName { get; set; }

    [JsonPropertyName("clientSecretCertificateThumbprint")]
    public string? ClientSecretCertificateThumbprint { get; set; }

    [JsonPropertyName("clientSecretSettingName")]
    public string? ClientSecretSettingName { get; set; }

    [JsonPropertyName("openIdIssuer")]
    public string? OpenIdIssuer { get; set; }
}
