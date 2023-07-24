using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.RestorePointCollections;


internal class WindowsVMGuestPatchAutomaticByPlatformSettingsModel
{
    [JsonPropertyName("bypassPlatformSafetyChecksOnUserSchedule")]
    public bool? BypassPlatformSafetyChecksOnUserSchedule { get; set; }

    [JsonPropertyName("rebootSetting")]
    public WindowsVMGuestPatchAutomaticByPlatformRebootSettingConstant? RebootSetting { get; set; }
}
