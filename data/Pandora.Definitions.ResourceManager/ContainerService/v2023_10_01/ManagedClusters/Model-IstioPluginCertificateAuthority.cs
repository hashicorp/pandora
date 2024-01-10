using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.ManagedClusters;


internal class IstioPluginCertificateAuthorityModel
{
    [JsonPropertyName("certChainObjectName")]
    public string? CertChainObjectName { get; set; }

    [JsonPropertyName("certObjectName")]
    public string? CertObjectName { get; set; }

    [JsonPropertyName("keyObjectName")]
    public string? KeyObjectName { get; set; }

    [JsonPropertyName("keyVaultId")]
    public string? KeyVaultId { get; set; }

    [JsonPropertyName("rootCertObjectName")]
    public string? RootCertObjectName { get; set; }
}
