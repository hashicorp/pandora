using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.DeletedWebApps;


internal class DeletedSitePropertiesModel
{
    [JsonPropertyName("deletedSiteId")]
    public int? DeletedSiteId { get; set; }

    [JsonPropertyName("deletedSiteName")]
    public string? DeletedSiteName { get; set; }

    [JsonPropertyName("deletedTimestamp")]
    public string? DeletedTimestamp { get; set; }

    [JsonPropertyName("geoRegionName")]
    public string? GeoRegionName { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("slot")]
    public string? Slot { get; set; }

    [JsonPropertyName("subscription")]
    public string? Subscription { get; set; }
}
