// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsDriverUpdateProfileModel
{
    [JsonPropertyName("approvalType")]
    public WindowsDriverUpdateProfileApprovalTypeConstant? ApprovalType { get; set; }

    [JsonPropertyName("assignments")]
    public List<WindowsDriverUpdateProfileAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deploymentDeferralInDays")]
    public int? DeploymentDeferralInDays { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceReporting")]
    public int? DeviceReporting { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("driverInventories")]
    public List<WindowsDriverUpdateInventoryModel>? DriverInventories { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inventorySyncStatus")]
    public WindowsDriverUpdateProfileInventorySyncStatusModel? InventorySyncStatus { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("newUpdates")]
    public int? NewUpdates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }
}
