// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceManagementPartnerModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("groupsRequiringPartnerEnrollment")]
    public List<DeviceManagementPartnerAssignmentModel>? GroupsRequiringPartnerEnrollment { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isConfigured")]
    public bool? IsConfigured { get; set; }

    [JsonPropertyName("lastHeartbeatDateTime")]
    public DateTime? LastHeartbeatDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("partnerAppType")]
    public DeviceManagementPartnerAppTypeConstant? PartnerAppType { get; set; }

    [JsonPropertyName("partnerState")]
    public DeviceManagementPartnerTenantStateConstant? PartnerState { get; set; }

    [JsonPropertyName("singleTenantAppId")]
    public string? SingleTenantAppId { get; set; }

    [JsonPropertyName("whenPartnerDevicesWillBeMarkedAsNonCompliantDateTime")]
    public DateTime? WhenPartnerDevicesWillBeMarkedAsNonCompliantDateTime { get; set; }

    [JsonPropertyName("whenPartnerDevicesWillBeRemovedDateTime")]
    public DateTime? WhenPartnerDevicesWillBeRemovedDateTime { get; set; }
}
