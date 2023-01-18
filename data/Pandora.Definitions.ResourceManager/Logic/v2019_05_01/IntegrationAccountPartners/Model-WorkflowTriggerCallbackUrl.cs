using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountPartners;


internal class WorkflowTriggerCallbackUrlModel
{
    [JsonPropertyName("basePath")]
    public string? BasePath { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("queries")]
    public WorkflowTriggerListCallbackUrlQueriesModel? Queries { get; set; }

    [JsonPropertyName("relativePath")]
    public string? RelativePath { get; set; }

    [JsonPropertyName("relativePathParameters")]
    public List<string>? RelativePathParameters { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
