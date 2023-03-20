using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ValueForType("ThreeTier")]
internal class ThreeTierConfigurationModel : InfrastructureConfigurationModel
{
    [JsonPropertyName("applicationServer")]
    [Required]
    public ApplicationServerConfigurationModel ApplicationServer { get; set; }

    [JsonPropertyName("centralServer")]
    [Required]
    public CentralServerConfigurationModel CentralServer { get; set; }

    [JsonPropertyName("customResourceNames")]
    public ThreeTierCustomResourceNamesModel? CustomResourceNames { get; set; }

    [JsonPropertyName("databaseServer")]
    [Required]
    public DatabaseConfigurationModel DatabaseServer { get; set; }

    [JsonPropertyName("highAvailabilityConfig")]
    public HighAvailabilityConfigurationModel? HighAvailabilityConfig { get; set; }

    [JsonPropertyName("networkConfiguration")]
    public NetworkConfigurationModel? NetworkConfiguration { get; set; }

    [JsonPropertyName("storageConfiguration")]
    public StorageConfigurationModel? StorageConfiguration { get; set; }
}
