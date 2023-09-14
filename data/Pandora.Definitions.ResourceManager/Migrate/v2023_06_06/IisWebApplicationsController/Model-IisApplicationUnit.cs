using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.IisWebApplicationsController;


internal class IisApplicationUnitModel
{
    [JsonPropertyName("applicationPoolName")]
    public string? ApplicationPoolName { get; set; }

    [JsonPropertyName("directories")]
    public List<DirectoryPathModel>? Directories { get; set; }

    [JsonPropertyName("enable32BitApiOnWin64")]
    public bool? Enable32BitApiOnWin64 { get; set; }

    [JsonPropertyName("managedPipelineMode")]
    public string? ManagedPipelineMode { get; set; }

    [JsonPropertyName("path")]
    public DirectoryPathModel? Path { get; set; }

    [JsonPropertyName("runtimeVersion")]
    public string? RuntimeVersion { get; set; }
}
