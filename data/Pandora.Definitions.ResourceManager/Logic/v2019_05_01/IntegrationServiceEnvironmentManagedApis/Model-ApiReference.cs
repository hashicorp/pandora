using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;


internal class ApiReferenceModel
{
    [JsonPropertyName("brandColor")]
    public string? BrandColor { get; set; }

    [JsonPropertyName("category")]
    public ApiTierConstant? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("iconUri")]
    public string? IconUri { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("integrationServiceEnvironment")]
    public ResourceReferenceModel? IntegrationServiceEnvironment { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("swagger")]
    public object? Swagger { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
