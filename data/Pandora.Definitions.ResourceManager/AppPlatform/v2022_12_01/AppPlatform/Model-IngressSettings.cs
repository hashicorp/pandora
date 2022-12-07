using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class IngressSettingsModel
{
    [JsonPropertyName("backendProtocol")]
    public BackendProtocolConstant? BackendProtocol { get; set; }

    [JsonPropertyName("clientAuth")]
    public IngressSettingsClientAuthModel? ClientAuth { get; set; }

    [JsonPropertyName("readTimeoutInSeconds")]
    public int? ReadTimeoutInSeconds { get; set; }

    [JsonPropertyName("sendTimeoutInSeconds")]
    public int? SendTimeoutInSeconds { get; set; }

    [JsonPropertyName("sessionAffinity")]
    public SessionAffinityConstant? SessionAffinity { get; set; }

    [JsonPropertyName("sessionCookieMaxAge")]
    public int? SessionCookieMaxAge { get; set; }
}
