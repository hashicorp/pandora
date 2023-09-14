using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.VMwarePropertiesController;


internal class DependencyMapMachineInputModel
{
    [JsonPropertyName("isDependencyMapToBeEnabled")]
    public bool? IsDependencyMapToBeEnabled { get; set; }

    [JsonPropertyName("machineId")]
    public string? MachineId { get; set; }
}
