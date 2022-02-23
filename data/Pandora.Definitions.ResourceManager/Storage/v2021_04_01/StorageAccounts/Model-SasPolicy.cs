using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class SasPolicyModel
{
    [JsonPropertyName("expirationAction")]
    [Required]
    public ExpirationActionConstant ExpirationAction { get; set; }

    [JsonPropertyName("sasExpirationPeriod")]
    [Required]
    public string SasExpirationPeriod { get; set; }
}
