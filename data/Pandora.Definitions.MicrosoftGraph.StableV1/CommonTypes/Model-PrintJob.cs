// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PrintJobModel
{
    [JsonPropertyName("configuration")]
    public PrintJobConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("createdBy")]
    public UserIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("documents")]
    public List<PrintDocumentModel>? Documents { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isFetchable")]
    public bool? IsFetchable { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("redirectedFrom")]
    public string? RedirectedFrom { get; set; }

    [JsonPropertyName("redirectedTo")]
    public string? RedirectedTo { get; set; }

    [JsonPropertyName("status")]
    public PrintJobStatusModel? Status { get; set; }

    [JsonPropertyName("tasks")]
    public List<PrintTaskModel>? Tasks { get; set; }
}
