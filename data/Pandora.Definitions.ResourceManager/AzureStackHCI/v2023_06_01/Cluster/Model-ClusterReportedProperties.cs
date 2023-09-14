using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.Cluster;


internal class ClusterReportedPropertiesModel
{
    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("clusterName")]
    public string? ClusterName { get; set; }

    [JsonPropertyName("clusterType")]
    public ClusterNodeTypeConstant? ClusterType { get; set; }

    [JsonPropertyName("clusterVersion")]
    public string? ClusterVersion { get; set; }

    [JsonPropertyName("diagnosticLevel")]
    public DiagnosticLevelConstant? DiagnosticLevel { get; set; }

    [JsonPropertyName("imdsAttestation")]
    public ImdsAttestationConstant? ImdsAttestation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("nodes")]
    public List<ClusterNodeModel>? Nodes { get; set; }

    [JsonPropertyName("oemActivation")]
    public OemActivationConstant? OemActivation { get; set; }

    [JsonPropertyName("supportedCapabilities")]
    public List<string>? SupportedCapabilities { get; set; }
}
