using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account;


internal class AccountUpdateParametersModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemOrUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("properties")]
    public AccountPropertiesModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
