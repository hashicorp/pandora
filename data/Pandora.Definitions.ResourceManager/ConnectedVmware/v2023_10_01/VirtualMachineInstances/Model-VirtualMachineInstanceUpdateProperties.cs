using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineInstances;


internal class VirtualMachineInstanceUpdatePropertiesModel
{
    [JsonPropertyName("hardwareProfile")]
    public HardwareProfileModel? HardwareProfile { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileUpdateModel? NetworkProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileUpdateModel? StorageProfile { get; set; }
}
