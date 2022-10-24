using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.ApplicationPackage;


internal class ApplicationPackagePropertiesModel
{
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastActivationTime")]
    public DateTime? LastActivationTime { get; set; }

    [JsonPropertyName("state")]
    public PackageStateConstant? State { get; set; }

    [JsonPropertyName("storageUrl")]
    public string? StorageUrl { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("storageUrlExpiry")]
    public DateTime? StorageUrlExpiry { get; set; }
}
