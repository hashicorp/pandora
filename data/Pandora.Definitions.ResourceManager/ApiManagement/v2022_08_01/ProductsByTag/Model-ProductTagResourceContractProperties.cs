using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ProductsByTag;


internal class ProductTagResourceContractPropertiesModel
{
    [JsonPropertyName("approvalRequired")]
    public bool? ApprovalRequired { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("state")]
    public ProductStateConstant? State { get; set; }

    [JsonPropertyName("subscriptionRequired")]
    public bool? SubscriptionRequired { get; set; }

    [JsonPropertyName("subscriptionsLimit")]
    public int? SubscriptionsLimit { get; set; }

    [JsonPropertyName("terms")]
    public string? Terms { get; set; }
}
