using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Roles;


internal class EdgeProfileSubscriptionModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("properties")]
    public SubscriptionPropertiesModel? Properties { get; set; }

    [JsonPropertyName("registrationDate")]
    public string? RegistrationDate { get; set; }

    [JsonPropertyName("registrationId")]
    public string? RegistrationId { get; set; }

    [JsonPropertyName("state")]
    public SubscriptionStateConstant? State { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }
}
