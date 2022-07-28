using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;


internal class PolicySettingsModel
{
    [JsonPropertyName("fileUploadLimitInMb")]
    public int? FileUploadLimitInMb { get; set; }

    [JsonPropertyName("maxRequestBodySizeInKb")]
    public int? MaxRequestBodySizeInKb { get; set; }

    [JsonPropertyName("mode")]
    public WebApplicationFirewallModeConstant? Mode { get; set; }

    [JsonPropertyName("requestBodyCheck")]
    public bool? RequestBodyCheck { get; set; }

    [JsonPropertyName("state")]
    public WebApplicationFirewallEnabledStateConstant? State { get; set; }
}
