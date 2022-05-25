using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.ListServiceProviders;


internal class ServiceProviderPropertiesModel
{
    [JsonPropertyName("devPortalUrl")]
    public string? DevPortalUrl { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("parameters")]
    public List<ServiceProviderParameterModel>? Parameters { get; set; }

    [JsonPropertyName("serviceProviderName")]
    public string? ServiceProviderName { get; set; }
}
