// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrinterUsageSummaryModel
{
    [JsonPropertyName("completedJobCount")]
    public int? CompletedJobCount { get; set; }

    [JsonPropertyName("incompleteJobCount")]
    public int? IncompleteJobCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("printer")]
    public DirectoryObjectModel? Printer { get; set; }

    [JsonPropertyName("printerDisplayName")]
    public string? PrinterDisplayName { get; set; }

    [JsonPropertyName("printerId")]
    public string? PrinterId { get; set; }

    [JsonPropertyName("printerManufacturer")]
    public string? PrinterManufacturer { get; set; }

    [JsonPropertyName("printerModel")]
    public string? PrinterModel { get; set; }
}
