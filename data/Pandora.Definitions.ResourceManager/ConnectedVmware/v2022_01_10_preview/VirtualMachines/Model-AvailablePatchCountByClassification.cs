using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;


internal class AvailablePatchCountByClassificationModel
{
    [JsonPropertyName("critical")]
    public int? Critical { get; set; }

    [JsonPropertyName("definition")]
    public int? Definition { get; set; }

    [JsonPropertyName("featurePack")]
    public int? FeaturePack { get; set; }

    [JsonPropertyName("other")]
    public int? Other { get; set; }

    [JsonPropertyName("security")]
    public int? Security { get; set; }

    [JsonPropertyName("servicePack")]
    public int? ServicePack { get; set; }

    [JsonPropertyName("tools")]
    public int? Tools { get; set; }

    [JsonPropertyName("updateRollup")]
    public int? UpdateRollup { get; set; }

    [JsonPropertyName("updates")]
    public int? Updates { get; set; }
}
