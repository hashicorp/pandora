using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Backend;


internal class BackendServiceFabricClusterPropertiesModel
{
    [JsonPropertyName("clientCertificateId")]
    public string? ClientCertificateId { get; set; }

    [JsonPropertyName("clientCertificatethumbprint")]
    public string? ClientCertificatethumbprint { get; set; }

    [JsonPropertyName("managementEndpoints")]
    [Required]
    public List<string> ManagementEndpoints { get; set; }

    [JsonPropertyName("maxPartitionResolutionRetries")]
    public int? MaxPartitionResolutionRetries { get; set; }

    [JsonPropertyName("serverCertificateThumbprints")]
    public List<string>? ServerCertificateThumbprints { get; set; }

    [JsonPropertyName("serverX509Names")]
    public List<X509CertificateNameModel>? ServerX509Names { get; set; }
}
