using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2019_06_01.RegistrationDefinitions;


internal class RegistrationDefinitionModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("plan")]
    public PlanModel? Plan { get; set; }

    [JsonPropertyName("properties")]
    public RegistrationDefinitionPropertiesModel? Properties { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
