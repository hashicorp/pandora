using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.Snapshots;


internal class SnapshotRestoreFilesModel
{
    [JsonPropertyName("destinationPath")]
    public string? DestinationPath { get; set; }

    [MinItems(1)]
    [MaxItems(10)]
    [JsonPropertyName("filePaths")]
    [Required]
    public List<string> FilePaths { get; set; }
}
