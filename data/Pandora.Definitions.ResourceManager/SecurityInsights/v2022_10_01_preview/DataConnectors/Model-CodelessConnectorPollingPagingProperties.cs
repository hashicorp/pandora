using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectors;


internal class CodelessConnectorPollingPagingPropertiesModel
{
    [JsonPropertyName("nextPageParaName")]
    public string? NextPageParaName { get; set; }

    [JsonPropertyName("nextPageTokenJsonPath")]
    public string? NextPageTokenJsonPath { get; set; }

    [JsonPropertyName("pageCountAttributePath")]
    public string? PageCountAttributePath { get; set; }

    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    [JsonPropertyName("pageSizeParaName")]
    public string? PageSizeParaName { get; set; }

    [JsonPropertyName("pageTimeStampAttributePath")]
    public string? PageTimeStampAttributePath { get; set; }

    [JsonPropertyName("pageTotalCountAttributePath")]
    public string? PageTotalCountAttributePath { get; set; }

    [JsonPropertyName("pagingType")]
    [Required]
    public string PagingType { get; set; }

    [JsonPropertyName("searchTheLatestTimeStampFromEventsList")]
    public string? SearchTheLatestTimeStampFromEventsList { get; set; }
}
