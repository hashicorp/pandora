using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.BackupProtectedItems;


internal class ExtendedPropertiesModel
{
    [JsonPropertyName("diskExclusionProperties")]
    public DiskExclusionPropertiesModel? DiskExclusionProperties { get; set; }

    [JsonPropertyName("linuxVmApplicationName")]
    public string? LinuxVMApplicationName { get; set; }
}
