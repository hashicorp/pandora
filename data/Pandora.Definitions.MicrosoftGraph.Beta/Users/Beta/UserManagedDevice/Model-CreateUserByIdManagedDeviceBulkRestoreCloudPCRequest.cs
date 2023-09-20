// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

internal class CreateUserByIdManagedDeviceBulkRestoreCloudPCRequestModel
{
    [JsonPropertyName("managedDeviceIds")]
    public List<string>? ManagedDeviceIds { get; set; }

    [JsonPropertyName("restorePointDateTime")]
    public DateTime? RestorePointDateTime { get; set; }

    [JsonPropertyName("timeRange")]
    public CreateUserByIdManagedDeviceBulkRestoreCloudPCRequestTimeRangeConstant? TimeRange { get; set; }
}
