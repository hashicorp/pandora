using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.VTwoWorkspaceConnectionResource;


internal abstract class WorkspaceConnectionPropertiesVTwoModel
{
    [JsonPropertyName("authType")]
    [ProvidesTypeHint]
    [Required]
    public ConnectionAuthTypeConstant AuthType { get; set; }

    [JsonPropertyName("category")]
    public ConnectionCategoryConstant? Category { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("valueFormat")]
    public ValueFormatConstant? ValueFormat { get; set; }
}
