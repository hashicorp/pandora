using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlSitesController;


internal class SiteErrorSummaryModel
{
    [JsonPropertyName("applianceName")]
    [Required]
    public string ApplianceName { get; set; }

    [JsonPropertyName("discoveryScopeErrorSummaries")]
    [Required]
    public DiscoveryScopeErrorSummaryModel DiscoveryScopeErrorSummaries { get; set; }

    [JsonPropertyName("nextLink")]
    public string? NextLink { get; set; }
}
