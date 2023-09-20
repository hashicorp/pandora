// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WorkbookTableModel
{
    [JsonPropertyName("columns")]
    public List<WorkbookTableColumnModel>? Columns { get; set; }

    [JsonPropertyName("highlightFirstColumn")]
    public bool? HighlightFirstColumn { get; set; }

    [JsonPropertyName("highlightLastColumn")]
    public bool? HighlightLastColumn { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("legacyId")]
    public string? LegacyId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rows")]
    public List<WorkbookTableRowModel>? Rows { get; set; }

    [JsonPropertyName("showBandedColumns")]
    public bool? ShowBandedColumns { get; set; }

    [JsonPropertyName("showBandedRows")]
    public bool? ShowBandedRows { get; set; }

    [JsonPropertyName("showFilterButton")]
    public bool? ShowFilterButton { get; set; }

    [JsonPropertyName("showHeaders")]
    public bool? ShowHeaders { get; set; }

    [JsonPropertyName("showTotals")]
    public bool? ShowTotals { get; set; }

    [JsonPropertyName("sort")]
    public WorkbookTableSortModel? Sort { get; set; }

    [JsonPropertyName("style")]
    public string? Style { get; set; }

    [JsonPropertyName("worksheet")]
    public WorkbookWorksheetModel? Worksheet { get; set; }
}
