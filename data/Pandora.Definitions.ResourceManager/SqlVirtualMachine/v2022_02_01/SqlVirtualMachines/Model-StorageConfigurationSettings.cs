using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class StorageConfigurationSettingsModel
{
    [JsonPropertyName("diskConfigurationType")]
    public DiskConfigurationTypeConstant? DiskConfigurationType { get; set; }

    [JsonPropertyName("sqlDataSettings")]
    public SQLStorageSettingsModel? SqlDataSettings { get; set; }

    [JsonPropertyName("sqlLogSettings")]
    public SQLStorageSettingsModel? SqlLogSettings { get; set; }

    [JsonPropertyName("sqlSystemDbOnDataDisk")]
    public bool? SqlSystemDbOnDataDisk { get; set; }

    [JsonPropertyName("sqlTempDbSettings")]
    public SQLTempDbSettingsModel? SqlTempDbSettings { get; set; }

    [JsonPropertyName("storageWorkloadType")]
    public StorageWorkloadTypeConstant? StorageWorkloadType { get; set; }
}
