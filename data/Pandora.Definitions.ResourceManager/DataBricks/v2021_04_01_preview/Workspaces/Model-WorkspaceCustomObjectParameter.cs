using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2021_04_01_preview.Workspaces;


internal class WorkspaceCustomObjectParameterModel
{
    [JsonPropertyName("type")]
    public CustomParameterTypeConstant? Type { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public object Value { get; set; }
}
