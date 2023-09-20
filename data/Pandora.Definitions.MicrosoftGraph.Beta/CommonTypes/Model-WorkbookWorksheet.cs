// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookWorksheetModel
{
    [JsonPropertyName("charts")]
    public List<WorkbookChartModel>? Charts { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("names")]
    public List<WorkbookNamedItemModel>? Names { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pivotTables")]
    public List<WorkbookPivotTableModel>? PivotTables { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("protection")]
    public WorkbookWorksheetProtectionModel? Protection { get; set; }

    [JsonPropertyName("tables")]
    public List<WorkbookTableModel>? Tables { get; set; }

    [JsonPropertyName("tasks")]
    public List<WorkbookDocumentTaskModel>? Tasks { get; set; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; set; }
}
