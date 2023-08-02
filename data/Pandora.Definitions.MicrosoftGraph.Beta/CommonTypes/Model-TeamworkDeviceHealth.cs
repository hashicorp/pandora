// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDeviceHealthModel
{
    [JsonPropertyName("connection")]
    public TeamworkConnectionModel? Connection { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("hardwareHealth")]
    public TeamworkHardwareHealthModel? HardwareHealth { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("loginStatus")]
    public TeamworkLoginStatusModel? LoginStatus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("peripheralsHealth")]
    public TeamworkPeripheralsHealthModel? PeripheralsHealth { get; set; }

    [JsonPropertyName("softwareUpdateHealth")]
    public TeamworkSoftwareUpdateHealthModel? SoftwareUpdateHealth { get; set; }
}
