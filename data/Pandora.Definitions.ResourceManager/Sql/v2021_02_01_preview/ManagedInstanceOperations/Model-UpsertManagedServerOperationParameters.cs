using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstanceOperations;


internal class UpsertManagedServerOperationParametersModel
{
    [JsonPropertyName("family")]
    public string? Family { get; set; }

    [JsonPropertyName("storageSizeInGB")]
    public int? StorageSizeInGB { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }

    [JsonPropertyName("vCores")]
    public int? VCores { get; set; }
}
