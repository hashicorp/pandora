// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcExternalPartnerSettingModel
{
    [JsonPropertyName("enableConnection")]
    public bool? EnableConnection { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; set; }

    [JsonPropertyName("status")]
    public CloudPcExternalPartnerStatusConstant? Status { get; set; }

    [JsonPropertyName("statusDetails")]
    public string? StatusDetails { get; set; }
}
