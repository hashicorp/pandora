// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionsManagementModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionsRequestChanges")]
    public List<PermissionsRequestChangeModel>? PermissionsRequestChanges { get; set; }

    [JsonPropertyName("scheduledPermissionsRequests")]
    public List<ScheduledPermissionsRequestModel>? ScheduledPermissionsRequests { get; set; }
}
