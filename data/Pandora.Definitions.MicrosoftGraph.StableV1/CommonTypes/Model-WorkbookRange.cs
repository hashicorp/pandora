// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WorkbookRangeModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("addressLocal")]
    public string? AddressLocal { get; set; }

    [JsonPropertyName("cellCount")]
    public int? CellCount { get; set; }

    [JsonPropertyName("columnCount")]
    public int? ColumnCount { get; set; }

    [JsonPropertyName("columnHidden")]
    public bool? ColumnHidden { get; set; }

    [JsonPropertyName("columnIndex")]
    public int? ColumnIndex { get; set; }

    [JsonPropertyName("format")]
    public WorkbookRangeFormatModel? Format { get; set; }

    [JsonPropertyName("formulas")]
    public JsonModel? Formulas { get; set; }

    [JsonPropertyName("formulasLocal")]
    public JsonModel? FormulasLocal { get; set; }

    [JsonPropertyName("formulasR1C1")]
    public JsonModel? FormulasR1C1 { get; set; }

    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("numberFormat")]
    public JsonModel? NumberFormat { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rowCount")]
    public int? RowCount { get; set; }

    [JsonPropertyName("rowHidden")]
    public bool? RowHidden { get; set; }

    [JsonPropertyName("rowIndex")]
    public int? RowIndex { get; set; }

    [JsonPropertyName("sort")]
    public WorkbookRangeSortModel? Sort { get; set; }

    [JsonPropertyName("text")]
    public JsonModel? Text { get; set; }

    [JsonPropertyName("valueTypes")]
    public JsonModel? ValueTypes { get; set; }

    [JsonPropertyName("values")]
    public JsonModel? Values { get; set; }

    [JsonPropertyName("worksheet")]
    public WorkbookWorksheetModel? Worksheet { get; set; }
}
