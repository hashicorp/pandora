using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlSitesController;


internal class DiscoveryScopeErrorSummaryModel
{
    [JsonPropertyName("affectedObjectsCount")]
    [Required]
    public int AffectedObjectsCount { get; set; }

    [JsonPropertyName("affectedResourceType")]
    [Required]
    public string AffectedResourceType { get; set; }

    [JsonPropertyName("discoveryScope")]
    [Required]
    public DiscoveryScopesConstant DiscoveryScope { get; set; }
}
