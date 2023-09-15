using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Hubs;


internal class NotificationHubPropertiesModel
{
    [JsonPropertyName("admCredential")]
    public AdmCredentialModel? AdmCredential { get; set; }

    [JsonPropertyName("apnsCredential")]
    public ApnsCredentialModel? ApnsCredential { get; set; }

    [JsonPropertyName("authorizationRules")]
    public List<SharedAccessAuthorizationRulePropertiesModel>? AuthorizationRules { get; set; }

    [JsonPropertyName("baiduCredential")]
    public BaiduCredentialModel? BaiduCredential { get; set; }

    [JsonPropertyName("browserCredential")]
    public BrowserCredentialModel? BrowserCredential { get; set; }

    [JsonPropertyName("dailyMaxActiveDevices")]
    public int? DailyMaxActiveDevices { get; set; }

    [JsonPropertyName("gcmCredential")]
    public GcmCredentialModel? GcmCredential { get; set; }

    [JsonPropertyName("mpnsCredential")]
    public MpnsCredentialModel? MpnsCredential { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("registrationTtl")]
    public string? RegistrationTtl { get; set; }

    [JsonPropertyName("wnsCredential")]
    public WnsCredentialModel? WnsCredential { get; set; }

    [JsonPropertyName("xiaomiCredential")]
    public XiaomiCredentialModel? XiaomiCredential { get; set; }
}
