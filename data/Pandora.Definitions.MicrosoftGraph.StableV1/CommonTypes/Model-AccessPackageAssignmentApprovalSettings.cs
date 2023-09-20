// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentApprovalSettingsModel
{
    [JsonPropertyName("isApprovalRequiredForAdd")]
    public bool? IsApprovalRequiredForAdd { get; set; }

    [JsonPropertyName("isApprovalRequiredForUpdate")]
    public bool? IsApprovalRequiredForUpdate { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("stages")]
    public List<AccessPackageApprovalStageModel>? Stages { get; set; }
}
