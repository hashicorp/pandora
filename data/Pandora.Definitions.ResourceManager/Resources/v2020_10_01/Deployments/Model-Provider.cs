using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Deployments;


internal class ProviderModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("registrationPolicy")]
    public string? RegistrationPolicy { get; set; }

    [JsonPropertyName("registrationState")]
    public string? RegistrationState { get; set; }

    [JsonPropertyName("resourceTypes")]
    public List<ProviderResourceTypeModel>? ResourceTypes { get; set; }
}
