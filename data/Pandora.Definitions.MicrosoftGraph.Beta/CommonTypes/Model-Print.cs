// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrintModel
{
    [JsonPropertyName("connectors")]
    public List<PrintConnectorModel>? Connectors { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<PrintOperationModel>? Operations { get; set; }

    [JsonPropertyName("printerShares")]
    public List<PrinterShareModel>? PrinterShares { get; set; }

    [JsonPropertyName("printers")]
    public List<PrinterModel>? Printers { get; set; }

    [JsonPropertyName("services")]
    public List<PrintServiceModel>? Services { get; set; }

    [JsonPropertyName("settings")]
    public PrintSettingsModel? Settings { get; set; }

    [JsonPropertyName("shares")]
    public List<PrinterShareModel>? Shares { get; set; }

    [JsonPropertyName("taskDefinitions")]
    public List<PrintTaskDefinitionModel>? TaskDefinitions { get; set; }
}
