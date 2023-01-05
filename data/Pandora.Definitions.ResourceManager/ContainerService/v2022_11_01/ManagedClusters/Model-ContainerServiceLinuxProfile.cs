using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;


internal class ContainerServiceLinuxProfileModel
{
    [JsonPropertyName("adminUsername")]
    [Required]
    public string AdminUsername { get; set; }

    [JsonPropertyName("ssh")]
    [Required]
    public ContainerServiceSshConfigurationModel Ssh { get; set; }
}
