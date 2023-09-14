using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervDependencyMapController;


internal class DependencyMapServiceMapextensionsDependencyMapRequestFiltersModel
{
    [JsonPropertyName("machineIds")]
    public List<string>? MachineIds { get; set; }

    [JsonPropertyName("processIds")]
    public List<string>? ProcessIds { get; set; }
}
