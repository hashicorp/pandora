using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2022_01_31_preview.ManagedIdentities;


internal class AzureResourceModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("subscriptionDisplayName")]
    public string? SubscriptionDisplayName { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
