using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineInstances;


internal class InfrastructureProfileModel
{
    [JsonPropertyName("biosGuid")]
    public string? BiosGuid { get; set; }

    [JsonPropertyName("checkpointType")]
    public string? CheckpointType { get; set; }

    [JsonPropertyName("checkpoints")]
    public List<CheckpointModel>? Checkpoints { get; set; }

    [JsonPropertyName("cloudId")]
    public string? CloudId { get; set; }

    [JsonPropertyName("generation")]
    public int? Generation { get; set; }

    [JsonPropertyName("inventoryItemId")]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("lastRestoredVMCheckpoint")]
    public CheckpointModel? LastRestoredVMCheckpoint { get; set; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    [JsonPropertyName("vmmServerId")]
    public string? VMmServerId { get; set; }

    [JsonPropertyName("vmName")]
    public string? VirtualMachineName { get; set; }
}
