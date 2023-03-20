using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ValueForType("DeploymentWithOSConfig")]
internal class DeploymentWithOSConfigurationModel : SAPConfigurationModel
{
    [JsonPropertyName("appLocation")]
    public string? AppLocation { get; set; }

    [JsonPropertyName("infrastructureConfiguration")]
    public InfrastructureConfigurationModel? InfrastructureConfiguration { get; set; }

    [JsonPropertyName("osSapConfiguration")]
    public OsSapConfigurationModel? OsSapConfiguration { get; set; }

    [JsonPropertyName("softwareConfiguration")]
    public SoftwareConfigurationModel? SoftwareConfiguration { get; set; }
}
