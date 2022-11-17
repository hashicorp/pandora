using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_10_01.UpdateSummaries;


internal class UpdateSummariesPropertiesModel
{
    [JsonPropertyName("currentVersion")]
    public string? CurrentVersion { get; set; }

    [JsonPropertyName("hardwareModel")]
    public string? HardwareModel { get; set; }

    [JsonPropertyName("oemFamily")]
    public string? OemFamily { get; set; }

    [JsonPropertyName("packageVersions")]
    public List<PackageVersionInfoModel>? PackageVersions { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("state")]
    public UpdateSummariesPropertiesStateConstant? State { get; set; }
}
