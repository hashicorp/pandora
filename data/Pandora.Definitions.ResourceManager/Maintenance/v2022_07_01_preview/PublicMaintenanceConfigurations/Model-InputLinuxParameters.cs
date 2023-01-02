using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.PublicMaintenanceConfigurations;


internal class InputLinuxParametersModel
{
    [JsonPropertyName("classificationsToInclude")]
    public List<string>? ClassificationsToInclude { get; set; }

    [JsonPropertyName("packageNameMasksToExclude")]
    public List<string>? PackageNameMasksToExclude { get; set; }

    [JsonPropertyName("packageNameMasksToInclude")]
    public List<string>? PackageNameMasksToInclude { get; set; }
}
