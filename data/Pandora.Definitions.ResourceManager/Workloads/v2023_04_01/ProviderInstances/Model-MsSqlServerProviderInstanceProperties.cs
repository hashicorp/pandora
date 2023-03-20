using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

[ValueForType("MsSqlServer")]
internal class MsSqlServerProviderInstancePropertiesModel : ProviderSpecificPropertiesModel
{
    [JsonPropertyName("dbPassword")]
    public string? DbPassword { get; set; }

    [JsonPropertyName("dbPasswordUri")]
    public string? DbPasswordUri { get; set; }

    [JsonPropertyName("dbPort")]
    public string? DbPort { get; set; }

    [JsonPropertyName("dbUsername")]
    public string? DbUsername { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("sapSid")]
    public string? SapSid { get; set; }

    [JsonPropertyName("sslCertificateUri")]
    public string? SslCertificateUri { get; set; }

    [JsonPropertyName("sslPreference")]
    public SslPreferenceConstant? SslPreference { get; set; }
}
