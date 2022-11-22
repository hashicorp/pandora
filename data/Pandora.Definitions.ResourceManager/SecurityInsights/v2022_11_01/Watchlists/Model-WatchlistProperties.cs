using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.Watchlists;


internal class WatchlistPropertiesModel
{
    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("createdBy")]
    public UserInfoModel? CreatedBy { get; set; }

    [JsonPropertyName("defaultDuration")]
    public string? DefaultDuration { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("itemsSearchKey")]
    [Required]
    public string ItemsSearchKey { get; set; }

    [JsonPropertyName("labels")]
    public List<string>? Labels { get; set; }

    [JsonPropertyName("numberOfLinesToSkip")]
    public int? NumberOfLinesToSkip { get; set; }

    [JsonPropertyName("provider")]
    [Required]
    public string Provider { get; set; }

    [JsonPropertyName("rawContent")]
    public string? RawContent { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public SourceConstant Source { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }

    [JsonPropertyName("updatedBy")]
    public UserInfoModel? UpdatedBy { get; set; }

    [JsonPropertyName("uploadStatus")]
    public string? UploadStatus { get; set; }

    [JsonPropertyName("watchlistAlias")]
    public string? WatchlistAlias { get; set; }

    [JsonPropertyName("watchlistId")]
    public string? WatchlistId { get; set; }

    [JsonPropertyName("watchlistType")]
    public string? WatchlistType { get; set; }
}
