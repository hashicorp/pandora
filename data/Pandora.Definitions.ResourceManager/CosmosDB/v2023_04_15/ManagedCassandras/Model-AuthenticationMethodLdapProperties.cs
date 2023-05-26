using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.ManagedCassandras;


internal class AuthenticationMethodLdapPropertiesModel
{
    [JsonPropertyName("connectionTimeoutInMs")]
    public int? ConnectionTimeoutInMs { get; set; }

    [JsonPropertyName("searchBaseDistinguishedName")]
    public string? SearchBaseDistinguishedName { get; set; }

    [JsonPropertyName("searchFilterTemplate")]
    public string? SearchFilterTemplate { get; set; }

    [JsonPropertyName("serverCertificates")]
    public List<CertificateModel>? ServerCertificates { get; set; }

    [JsonPropertyName("serverHostname")]
    public string? ServerHostname { get; set; }

    [JsonPropertyName("serverPort")]
    public int? ServerPort { get; set; }

    [JsonPropertyName("serviceUserDistinguishedName")]
    public string? ServiceUserDistinguishedName { get; set; }

    [JsonPropertyName("serviceUserPassword")]
    public string? ServiceUserPassword { get; set; }
}
