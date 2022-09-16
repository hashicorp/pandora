using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.Clusters;


internal class TableLevelSharingPropertiesModel
{
    [JsonPropertyName("externalTablesToExclude")]
    public List<string>? ExternalTablesToExclude { get; set; }

    [JsonPropertyName("externalTablesToInclude")]
    public List<string>? ExternalTablesToInclude { get; set; }

    [JsonPropertyName("materializedViewsToExclude")]
    public List<string>? MaterializedViewsToExclude { get; set; }

    [JsonPropertyName("materializedViewsToInclude")]
    public List<string>? MaterializedViewsToInclude { get; set; }

    [JsonPropertyName("tablesToExclude")]
    public List<string>? TablesToExclude { get; set; }

    [JsonPropertyName("tablesToInclude")]
    public List<string>? TablesToInclude { get; set; }
}
