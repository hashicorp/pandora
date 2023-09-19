// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCOrganizationSettingsModel
{
    [JsonPropertyName("enableMEMAutoEnroll")]
    public bool? EnableMEMAutoEnroll { get; set; }

    [JsonPropertyName("enableSingleSignOn")]
    public bool? EnableSingleSignOn { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osVersion")]
    public CloudPCOrganizationSettingsOsVersionConstant? OsVersion { get; set; }

    [JsonPropertyName("userAccountType")]
    public CloudPCOrganizationSettingsUserAccountTypeConstant? UserAccountType { get; set; }

    [JsonPropertyName("windowsSettings")]
    public CloudPCWindowsSettingsModel? WindowsSettings { get; set; }
}
