using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstanceDtcs;


internal class ManagedInstanceDtcPropertiesModel
{
    [JsonPropertyName("dtcEnabled")]
    public bool? DtcEnabled { get; set; }

    [JsonPropertyName("dtcHostNameDnsSuffix")]
    public string? DtcHostNameDnsSuffix { get; set; }

    [JsonPropertyName("externalDnsSuffixSearchList")]
    public List<string>? ExternalDnsSuffixSearchList { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("securitySettings")]
    public ManagedInstanceDtcSecuritySettingsModel? SecuritySettings { get; set; }
}
