using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Operations;


internal class DimensionModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("internalMetricName")]
    public string? InternalMetricName { get; set; }

    [JsonPropertyName("internalName")]
    public string? InternalName { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sourceMdmNamespace")]
    public string? SourceMdmNamespace { get; set; }

    [JsonPropertyName("toBeExportedToShoebox")]
    public bool? ToBeExportedToShoebox { get; set; }
}
