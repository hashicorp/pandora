using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;


internal class SwaggerCustomDynamicListModel
{
    [JsonPropertyName("builtInOperation")]
    public string? BuiltInOperation { get; set; }

    [JsonPropertyName("itemTitlePath")]
    public string? ItemTitlePath { get; set; }

    [JsonPropertyName("itemValuePath")]
    public string? ItemValuePath { get; set; }

    [JsonPropertyName("itemsPath")]
    public string? ItemsPath { get; set; }

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, SwaggerCustomDynamicPropertiesModel>? Parameters { get; set; }
}
