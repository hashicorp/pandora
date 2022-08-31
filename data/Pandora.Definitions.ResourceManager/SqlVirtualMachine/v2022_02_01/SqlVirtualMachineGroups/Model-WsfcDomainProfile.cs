using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachineGroups;


internal class WsfcDomainProfileModel
{
    [JsonPropertyName("clusterBootstrapAccount")]
    public string? ClusterBootstrapAccount { get; set; }

    [JsonPropertyName("clusterOperatorAccount")]
    public string? ClusterOperatorAccount { get; set; }

    [JsonPropertyName("clusterSubnetType")]
    public ClusterSubnetTypeConstant? ClusterSubnetType { get; set; }

    [JsonPropertyName("domainFqdn")]
    public string? DomainFqdn { get; set; }

    [JsonPropertyName("fileShareWitnessPath")]
    public string? FileShareWitnessPath { get; set; }

    [JsonPropertyName("ouPath")]
    public string? OuPath { get; set; }

    [JsonPropertyName("sqlServiceAccount")]
    public string? SqlServiceAccount { get; set; }

    [JsonPropertyName("storageAccountPrimaryKey")]
    public string? StorageAccountPrimaryKey { get; set; }

    [JsonPropertyName("storageAccountUrl")]
    public string? StorageAccountUrl { get; set; }
}
