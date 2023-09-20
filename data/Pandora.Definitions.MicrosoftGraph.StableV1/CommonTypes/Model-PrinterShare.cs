// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PrinterShareModel
{
    [JsonPropertyName("allowAllUsers")]
    public bool? AllowAllUsers { get; set; }

    [JsonPropertyName("allowedGroups")]
    public List<GroupModel>? AllowedGroups { get; set; }

    [JsonPropertyName("allowedUsers")]
    public List<UserModel>? AllowedUsers { get; set; }

    [JsonPropertyName("capabilities")]
    public PrinterCapabilitiesModel? Capabilities { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defaults")]
    public PrinterDefaultsModel? Defaults { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isAcceptingJobs")]
    public bool? IsAcceptingJobs { get; set; }

    [JsonPropertyName("jobs")]
    public List<PrintJobModel>? Jobs { get; set; }

    [JsonPropertyName("location")]
    public PrinterLocationModel? Location { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("printer")]
    public PrinterModel? Printer { get; set; }

    [JsonPropertyName("status")]
    public PrinterStatusModel? Status { get; set; }

    [JsonPropertyName("viewPoint")]
    public PrinterShareViewpointModel? ViewPoint { get; set; }
}
