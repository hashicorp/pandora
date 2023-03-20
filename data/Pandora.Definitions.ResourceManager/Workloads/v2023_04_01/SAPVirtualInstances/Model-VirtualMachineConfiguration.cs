using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;


internal class VirtualMachineConfigurationModel
{
    [JsonPropertyName("imageReference")]
    [Required]
    public ImageReferenceModel ImageReference { get; set; }

    [JsonPropertyName("osProfile")]
    [Required]
    public OSProfileModel OsProfile { get; set; }

    [JsonPropertyName("vmSize")]
    [Required]
    public string VMSize { get; set; }
}
