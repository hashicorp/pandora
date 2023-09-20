// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsDriverUpdateInventoryModel
{
    [JsonPropertyName("applicableDeviceCount")]
    public int? ApplicableDeviceCount { get; set; }

    [JsonPropertyName("approvalStatus")]
    public WindowsDriverUpdateInventoryApprovalStatusConstant? ApprovalStatus { get; set; }

    [JsonPropertyName("category")]
    public WindowsDriverUpdateInventoryCategoryConstant? Category { get; set; }

    [JsonPropertyName("deployDateTime")]
    public DateTime? DeployDateTime { get; set; }

    [JsonPropertyName("driverClass")]
    public string? DriverClass { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("releaseDateTime")]
    public DateTime? ReleaseDateTime { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
