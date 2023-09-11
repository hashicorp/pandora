using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;


internal class DevToolPortalPropertiesModel
{
    [JsonPropertyName("components")]
    public List<DevToolPortalComponentModel>? Components { get; set; }

    [JsonPropertyName("features")]
    public DevToolPortalFeatureSettingsModel? Features { get; set; }

    [JsonPropertyName("provisioningState")]
    public DevToolPortalProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("ssoProperties")]
    public DevToolPortalSsoPropertiesModel? SsoProperties { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
