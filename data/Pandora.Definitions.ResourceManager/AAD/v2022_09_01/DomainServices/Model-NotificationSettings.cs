using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2022_09_01.DomainServices;


internal class NotificationSettingsModel
{
    [JsonPropertyName("additionalRecipients")]
    public List<string>? AdditionalRecipients { get; set; }

    [JsonPropertyName("notifyDcAdmins")]
    public NotifyDcAdminsConstant? NotifyDcAdmins { get; set; }

    [JsonPropertyName("notifyGlobalAdmins")]
    public NotifyGlobalAdminsConstant? NotifyGlobalAdmins { get; set; }
}
