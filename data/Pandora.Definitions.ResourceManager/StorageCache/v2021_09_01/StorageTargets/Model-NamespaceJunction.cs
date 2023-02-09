using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.StorageTargets;


internal class NamespaceJunctionModel
{
    [JsonPropertyName("namespacePath")]
    public string? NamespacePath { get; set; }

    [JsonPropertyName("nfsAccessPolicy")]
    public string? NfsAccessPolicy { get; set; }

    [JsonPropertyName("nfsExport")]
    public string? NfsExport { get; set; }

    [JsonPropertyName("targetPath")]
    public string? TargetPath { get; set; }
}
