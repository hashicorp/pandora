// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RoleManagementModel
{
    [JsonPropertyName("cloudPC")]
    public RbacApplicationMultipleModel? CloudPC { get; set; }

    [JsonPropertyName("deviceManagement")]
    public RbacApplicationMultipleModel? DeviceManagement { get; set; }

    [JsonPropertyName("directory")]
    public RbacApplicationModel? Directory { get; set; }

    [JsonPropertyName("enterpriseApps")]
    public List<RbacApplicationModel>? EnterpriseApps { get; set; }

    [JsonPropertyName("entitlementManagement")]
    public RbacApplicationModel? EntitlementManagement { get; set; }

    [JsonPropertyName("exchange")]
    public UnifiedRbacApplicationModel? Exchange { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
