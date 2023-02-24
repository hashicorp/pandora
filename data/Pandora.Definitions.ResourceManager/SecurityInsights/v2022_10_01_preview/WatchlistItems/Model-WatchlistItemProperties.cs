using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.WatchlistItems;


internal class WatchlistItemPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("createdBy")]
    public UserInfoModel? CreatedBy { get; set; }

    [JsonPropertyName("entityMapping")]
    public object? EntityMapping { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("itemsKeyValue")]
    [Required]
    public object ItemsKeyValue { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }

    [JsonPropertyName("updatedBy")]
    public UserInfoModel? UpdatedBy { get; set; }

    [JsonPropertyName("watchlistItemId")]
    public string? WatchlistItemId { get; set; }

    [JsonPropertyName("watchlistItemType")]
    public string? WatchlistItemType { get; set; }
}
