// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RemoteActionAuditModel
{
    [JsonPropertyName("action")]
    public RemoteActionAuditActionConstant? Action { get; set; }

    [JsonPropertyName("actionState")]
    public RemoteActionAuditActionStateConstant? ActionState { get; set; }

    [JsonPropertyName("deviceDisplayName")]
    public string? DeviceDisplayName { get; set; }

    [JsonPropertyName("deviceIMEI")]
    public string? DeviceIMEI { get; set; }

    [JsonPropertyName("deviceOwnerUserPrincipalName")]
    public string? DeviceOwnerUserPrincipalName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("initiatedByUserPrincipalName")]
    public string? InitiatedByUserPrincipalName { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestDateTime")]
    public DateTime? RequestDateTime { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
