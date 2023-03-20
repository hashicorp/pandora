using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

[ValueForType("PrometheusHaCluster")]
internal class PrometheusHaClusterProviderInstancePropertiesModel : ProviderSpecificPropertiesModel
{
    [JsonPropertyName("clusterName")]
    public string? ClusterName { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("prometheusUrl")]
    public string? PrometheusUrl { get; set; }

    [JsonPropertyName("sid")]
    public string? Sid { get; set; }

    [JsonPropertyName("sslCertificateUri")]
    public string? SslCertificateUri { get; set; }

    [JsonPropertyName("sslPreference")]
    public SslPreferenceConstant? SslPreference { get; set; }
}
