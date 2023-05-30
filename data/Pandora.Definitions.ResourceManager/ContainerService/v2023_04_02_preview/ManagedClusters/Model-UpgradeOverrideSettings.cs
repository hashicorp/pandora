using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_04_02_preview.ManagedClusters;


internal class UpgradeOverrideSettingsModel
{
    [JsonPropertyName("controlPlaneOverrides")]
    public List<ControlPlaneUpgradeOverrideConstant>? ControlPlaneOverrides { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("until")]
    public DateTime? Until { get; set; }
}
