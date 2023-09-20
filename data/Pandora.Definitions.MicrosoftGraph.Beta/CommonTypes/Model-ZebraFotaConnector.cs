// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ZebraFotaConnectorModel
{
    [JsonPropertyName("enrollmentAuthorizationUrl")]
    public string? EnrollmentAuthorizationUrl { get; set; }

    [JsonPropertyName("enrollmentToken")]
    public string? EnrollmentToken { get; set; }

    [JsonPropertyName("fotaAppsApproved")]
    public bool? FotaAppsApproved { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public ZebraFotaConnectorStateConstant? State { get; set; }
}
