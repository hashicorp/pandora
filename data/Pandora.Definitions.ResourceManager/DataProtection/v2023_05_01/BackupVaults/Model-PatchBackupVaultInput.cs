using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_05_01.BackupVaults;


internal class PatchBackupVaultInputModel
{
    [JsonPropertyName("featureSettings")]
    public FeatureSettingsModel? FeatureSettings { get; set; }

    [JsonPropertyName("monitoringSettings")]
    public MonitoringSettingsModel? MonitoringSettings { get; set; }

    [JsonPropertyName("securitySettings")]
    public SecuritySettingsModel? SecuritySettings { get; set; }
}
