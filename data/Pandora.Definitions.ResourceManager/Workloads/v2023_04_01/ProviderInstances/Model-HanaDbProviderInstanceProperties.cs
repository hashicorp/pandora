using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

[ValueForType("SapHana")]
internal class HanaDbProviderInstancePropertiesModel : ProviderSpecificPropertiesModel
{
    [JsonPropertyName("dbName")]
    public string? DbName { get; set; }

    [JsonPropertyName("dbPassword")]
    public string? DbPassword { get; set; }

    [JsonPropertyName("dbPasswordUri")]
    public string? DbPasswordUri { get; set; }

    [JsonPropertyName("dbUsername")]
    public string? DbUsername { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("instanceNumber")]
    public string? InstanceNumber { get; set; }

    [JsonPropertyName("sapSid")]
    public string? SapSid { get; set; }

    [JsonPropertyName("sqlPort")]
    public string? SqlPort { get; set; }

    [JsonPropertyName("sslCertificateUri")]
    public string? SslCertificateUri { get; set; }

    [JsonPropertyName("sslHostNameInCertificate")]
    public string? SslHostNameInCertificate { get; set; }

    [JsonPropertyName("sslPreference")]
    public SslPreferenceConstant? SslPreference { get; set; }
}
