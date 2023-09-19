// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TenantSetupInfoModel
{
    [JsonPropertyName("defaultRolesSettings")]
    public PrivilegedRoleSettingsModel? DefaultRolesSettings { get; set; }

    [JsonPropertyName("firstTimeSetup")]
    public bool? FirstTimeSetup { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("relevantRolesSettings")]
    public List<string>? RelevantRolesSettings { get; set; }

    [JsonPropertyName("setupStatus")]
    public TenantSetupInfoSetupStatusConstant? SetupStatus { get; set; }

    [JsonPropertyName("skipSetup")]
    public bool? SkipSetup { get; set; }

    [JsonPropertyName("userRolesActions")]
    public string? UserRolesActions { get; set; }
}
