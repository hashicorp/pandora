using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

[ValueForType("SapNetWeaver")]
internal class SapNetWeaverProviderInstancePropertiesModel : ProviderSpecificPropertiesModel
{
    [JsonPropertyName("sapClientId")]
    public string? SapClientId { get; set; }

    [JsonPropertyName("sapHostFileEntries")]
    public List<string>? SapHostFileEntries { get; set; }

    [JsonPropertyName("sapHostname")]
    public string? SapHostname { get; set; }

    [JsonPropertyName("sapInstanceNr")]
    public string? SapInstanceNr { get; set; }

    [JsonPropertyName("sapPassword")]
    public string? SapPassword { get; set; }

    [JsonPropertyName("sapPasswordUri")]
    public string? SapPasswordUri { get; set; }

    [JsonPropertyName("sapPortNumber")]
    public string? SapPortNumber { get; set; }

    [JsonPropertyName("sapSid")]
    public string? SapSid { get; set; }

    [JsonPropertyName("sapUsername")]
    public string? SapUsername { get; set; }

    [JsonPropertyName("sslCertificateUri")]
    public string? SslCertificateUri { get; set; }

    [JsonPropertyName("sslPreference")]
    public SslPreferenceConstant? SslPreference { get; set; }
}
