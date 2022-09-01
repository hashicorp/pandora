using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class SqlStorageUpdateSettingsModel
{
    [JsonPropertyName("diskConfigurationType")]
    public DiskConfigurationTypeConstant? DiskConfigurationType { get; set; }

    [JsonPropertyName("diskCount")]
    public int? DiskCount { get; set; }

    [JsonPropertyName("startingDeviceId")]
    public int? StartingDeviceId { get; set; }
}
