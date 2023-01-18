using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;


internal class ApiOperationPropertiesDefinitionModel
{
    [JsonPropertyName("annotation")]
    public ApiOperationAnnotationModel? Annotation { get; set; }

    [JsonPropertyName("api")]
    public ApiReferenceModel? Api { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("inputsDefinition")]
    public SwaggerSchemaModel? InputsDefinition { get; set; }

    [JsonPropertyName("isNotification")]
    public bool? IsNotification { get; set; }

    [JsonPropertyName("isWebhook")]
    public bool? IsWebhook { get; set; }

    [JsonPropertyName("pageable")]
    public bool? Pageable { get; set; }

    [JsonPropertyName("responsesDefinition")]
    public Dictionary<string, SwaggerSchemaModel>? ResponsesDefinition { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("trigger")]
    public string? Trigger { get; set; }

    [JsonPropertyName("triggerHint")]
    public string? TriggerHint { get; set; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; set; }
}
