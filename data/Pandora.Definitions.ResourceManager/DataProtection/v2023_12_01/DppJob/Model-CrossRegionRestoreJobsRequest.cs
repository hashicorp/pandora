using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.DppJob;


internal class CrossRegionRestoreJobsRequestModel
{
    [JsonPropertyName("sourceBackupVaultId")]
    [Required]
    public string SourceBackupVaultId { get; set; }

    [JsonPropertyName("sourceRegion")]
    [Required]
    public string SourceRegion { get; set; }
}
