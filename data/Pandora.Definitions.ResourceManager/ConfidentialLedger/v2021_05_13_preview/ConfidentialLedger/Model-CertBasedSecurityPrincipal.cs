using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;


internal class CertBasedSecurityPrincipalModel
{
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    [JsonPropertyName("ledgerRoleName")]
    public LedgerRoleNameConstant? LedgerRoleName { get; set; }
}
