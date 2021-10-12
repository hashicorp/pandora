using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.DefaultAccount
{

    internal class DefaultAccountPayloadModel
    {
        [JsonPropertyName("accountName")]
        public string? AccountName { get; set; }

        [JsonPropertyName("resourceGroupName")]
        public string? ResourceGroupName { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        [JsonPropertyName("scopeTenantId")]
        public string? ScopeTenantId { get; set; }

        [JsonPropertyName("scopeType")]
        public ScopeTypeConstant? ScopeType { get; set; }

        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }
    }
}
