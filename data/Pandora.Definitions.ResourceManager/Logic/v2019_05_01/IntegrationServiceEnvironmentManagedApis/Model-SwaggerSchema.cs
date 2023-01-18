using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;


internal class SwaggerSchemaModel
{
    [JsonPropertyName("additionalProperties")]
    public object? AdditionalProperties { get; set; }

    [JsonPropertyName("allOf")]
    public List<SwaggerSchemaModel>? AllOf { get; set; }

    [JsonPropertyName("discriminator")]
    public string? Discriminator { get; set; }

    [JsonPropertyName("dynamicListNew")]
    public SwaggerCustomDynamicListModel? DynamicListNew { get; set; }

    [JsonPropertyName("dynamicSchemaNew")]
    public SwaggerCustomDynamicPropertiesModel? DynamicSchemaNew { get; set; }

    [JsonPropertyName("dynamicSchemaOld")]
    public SwaggerCustomDynamicSchemaModel? DynamicSchemaOld { get; set; }

    [JsonPropertyName("dynamicTree")]
    public SwaggerCustomDynamicTreeModel? DynamicTree { get; set; }

    [JsonPropertyName("example")]
    public object? Example { get; set; }

    [JsonPropertyName("externalDocs")]
    public SwaggerExternalDocumentationModel? ExternalDocs { get; set; }

    [JsonPropertyName("items")]
    public SwaggerSchemaModel? Items { get; set; }

    [JsonPropertyName("maxProperties")]
    public int? MaxProperties { get; set; }

    [JsonPropertyName("minProperties")]
    public int? MinProperties { get; set; }

    [JsonPropertyName("notificationUrlExtension")]
    public bool? NotificationUrlExtension { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, SwaggerSchemaModel>? Properties { get; set; }

    [JsonPropertyName("readOnly")]
    public bool? ReadOnly { get; set; }

    [JsonPropertyName("ref")]
    public string? Ref { get; set; }

    [JsonPropertyName("required")]
    public List<string>? Required { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public SwaggerSchemaTypeConstant? Type { get; set; }

    [JsonPropertyName("xml")]
    public SwaggerXmlModel? Xml { get; set; }
}
