using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ValueForType("SingleServer")]
internal class SingleServerConfigurationModel : InfrastructureConfigurationModel
{
    [JsonPropertyName("customResourceNames")]
    public SingleServerCustomResourceNamesModel? CustomResourceNames { get; set; }

    [JsonPropertyName("databaseType")]
    public SAPDatabaseTypeConstant? DatabaseType { get; set; }

    [JsonPropertyName("dbDiskConfiguration")]
    public DiskConfigurationModel? DbDiskConfiguration { get; set; }

    [JsonPropertyName("networkConfiguration")]
    public NetworkConfigurationModel? NetworkConfiguration { get; set; }

    [JsonPropertyName("subnetId")]
    [Required]
    public string SubnetId { get; set; }

    [JsonPropertyName("virtualMachineConfiguration")]
    [Required]
    public VirtualMachineConfigurationModel VirtualMachineConfiguration { get; set; }
}
