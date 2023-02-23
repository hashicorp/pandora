using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.Backups;


internal class BackupRestoreFilesModel
{
    [JsonPropertyName("destinationVolumeId")]
    [Required]
    public string DestinationVolumeId { get; set; }

    [MinItems(1)]
    [MaxItems(8)]
    [JsonPropertyName("fileList")]
    [Required]
    public List<string> FileList { get; set; }

    [JsonPropertyName("restoreFilePath")]
    public string? RestoreFilePath { get; set; }
}
