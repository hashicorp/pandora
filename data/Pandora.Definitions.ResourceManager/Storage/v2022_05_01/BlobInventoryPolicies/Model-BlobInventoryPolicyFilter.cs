using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.BlobInventoryPolicies;


internal class BlobInventoryPolicyFilterModel
{
    [JsonPropertyName("blobTypes")]
    public List<string>? BlobTypes { get; set; }

    [JsonPropertyName("excludePrefix")]
    public List<string>? ExcludePrefix { get; set; }

    [JsonPropertyName("includeBlobVersions")]
    public bool? IncludeBlobVersions { get; set; }

    [JsonPropertyName("includeDeleted")]
    public bool? IncludeDeleted { get; set; }

    [JsonPropertyName("includeSnapshots")]
    public bool? IncludeSnapshots { get; set; }

    [JsonPropertyName("prefixMatch")]
    public List<string>? PrefixMatch { get; set; }
}
