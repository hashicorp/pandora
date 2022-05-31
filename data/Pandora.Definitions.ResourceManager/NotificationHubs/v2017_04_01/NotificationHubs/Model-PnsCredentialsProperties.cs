using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2017_04_01.NotificationHubs;


internal class PnsCredentialsPropertiesModel
{
    [JsonPropertyName("admCredential")]
    public AdmCredentialModel? AdmCredential { get; set; }

    [JsonPropertyName("apnsCredential")]
    public ApnsCredentialModel? ApnsCredential { get; set; }

    [JsonPropertyName("baiduCredential")]
    public BaiduCredentialModel? BaiduCredential { get; set; }

    [JsonPropertyName("gcmCredential")]
    public GcmCredentialModel? GcmCredential { get; set; }

    [JsonPropertyName("mpnsCredential")]
    public MpnsCredentialModel? MpnsCredential { get; set; }

    [JsonPropertyName("wnsCredential")]
    public WnsCredentialModel? WnsCredential { get; set; }
}
