using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDatabaseInstances;


internal class DatabaseVMDetailsModel
{
    [JsonPropertyName("status")]
    public SAPVirtualInstanceStatusConstant? Status { get; set; }

    [JsonPropertyName("storageDetails")]
    public List<StorageInformationModel>? StorageDetails { get; set; }

    [JsonPropertyName("virtualMachineId")]
    public string? VirtualMachineId { get; set; }
}
