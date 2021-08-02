using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{

    internal class PrivateLinkServiceConnectionStateModel
    {
        [JsonPropertyName("actionsRequired")]
        public ActionsRequiredConstant? ActionsRequired { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        public ConnectionStatusConstant? Status { get; set; }
    }
}
