// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConfigurationManagerCollectionAssignmentTargetModel
{
    [JsonPropertyName("collectionId")]
    public string? CollectionId { get; set; }

    [JsonPropertyName("deviceAndAppManagementAssignmentFilterId")]
    public string? DeviceAndAppManagementAssignmentFilterId { get; set; }

    [JsonPropertyName("deviceAndAppManagementAssignmentFilterType")]
    public ConfigurationManagerCollectionAssignmentTargetDeviceAndAppManagementAssignmentFilterTypeConstant? DeviceAndAppManagementAssignmentFilterType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
