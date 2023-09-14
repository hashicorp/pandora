using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebApplicationsController;


internal class WebApplicationDirectoryUnitModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEditable")]
    public bool? IsEditable { get; set; }

    [JsonPropertyName("localScratchPath")]
    public string? LocalScratchPath { get; set; }

    [JsonPropertyName("mountPath")]
    public string? MountPath { get; set; }

    [JsonPropertyName("sourcePaths")]
    public List<string>? SourcePaths { get; set; }

    [JsonPropertyName("sourceSize")]
    public string? SourceSize { get; set; }
}
