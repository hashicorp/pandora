using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.NodeType;


internal class VmssDataDiskModel
{
    [JsonPropertyName("diskLetter")]
    [Required]
    public string DiskLetter { get; set; }

    [JsonPropertyName("diskSizeGB")]
    [Required]
    public int DiskSizeGB { get; set; }

    [JsonPropertyName("diskType")]
    [Required]
    public DiskTypeConstant DiskType { get; set; }

    [JsonPropertyName("lun")]
    [Required]
    public int Lun { get; set; }
}
