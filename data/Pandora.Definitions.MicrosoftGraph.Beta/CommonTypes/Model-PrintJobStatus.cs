// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrintJobStatusModel
{
    [JsonPropertyName("acquiredByPrinter")]
    public bool? AcquiredByPrinter { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("details")]
    public List<PrintJobStatusDetailsConstant>? Details { get; set; }

    [JsonPropertyName("isAcquiredByPrinter")]
    public bool? IsAcquiredByPrinter { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("processingState")]
    public PrintJobStatusProcessingStateConstant? ProcessingState { get; set; }

    [JsonPropertyName("processingStateDescription")]
    public string? ProcessingStateDescription { get; set; }

    [JsonPropertyName("state")]
    public PrintJobStatusStateConstant? State { get; set; }
}
