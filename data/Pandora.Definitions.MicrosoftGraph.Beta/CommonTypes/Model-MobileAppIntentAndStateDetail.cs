// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MobileAppIntentAndStateDetailModel
{
    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("displayVersion")]
    public string? DisplayVersion { get; set; }

    [JsonPropertyName("installState")]
    public MobileAppIntentAndStateDetailInstallStateConstant? InstallState { get; set; }

    [JsonPropertyName("mobileAppIntent")]
    public MobileAppIntentAndStateDetailMobileAppIntentConstant? MobileAppIntent { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("supportedDeviceTypes")]
    public List<MobileAppSupportedDeviceTypeModel>? SupportedDeviceTypes { get; set; }
}
