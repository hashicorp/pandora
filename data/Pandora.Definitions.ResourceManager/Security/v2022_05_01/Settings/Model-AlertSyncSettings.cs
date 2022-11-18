using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2022_05_01.Settings;

[ValueForType("AlertSyncSettings")]
internal class AlertSyncSettingsModel : SettingModel
{
    [JsonPropertyName("properties")]
    public AlertSyncSettingPropertiesModel? Properties { get; set; }
}
