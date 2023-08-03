// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcServicePlanModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("provisioningType")]
    public CloudPcProvisioningTypeConstant? ProvisioningType { get; set; }

    [JsonPropertyName("ramInGB")]
    public int? RamInGB { get; set; }

    [JsonPropertyName("storageInGB")]
    public int? StorageInGB { get; set; }

    [JsonPropertyName("supportedSolution")]
    public CloudPcManagementServiceConstant? SupportedSolution { get; set; }

    [JsonPropertyName("type")]
    public CloudPcServicePlanTypeConstant? Type { get; set; }

    [JsonPropertyName("userProfileInGB")]
    public int? UserProfileInGB { get; set; }

    [JsonPropertyName("vCpuCount")]
    public int? VCpuCount { get; set; }
}
