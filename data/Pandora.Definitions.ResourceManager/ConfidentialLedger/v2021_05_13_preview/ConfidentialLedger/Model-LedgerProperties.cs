using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2021_05_13_preview.ConfidentialLedger;


internal class LedgerPropertiesModel
{
    [JsonPropertyName("aadBasedSecurityPrincipals")]
    public List<AADBasedSecurityPrincipalModel>? AadBasedSecurityPrincipals { get; set; }

    [JsonPropertyName("certBasedSecurityPrincipals")]
    public List<CertBasedSecurityPrincipalModel>? CertBasedSecurityPrincipals { get; set; }

    [JsonPropertyName("identityServiceUri")]
    public string? IdentityServiceUri { get; set; }

    [JsonPropertyName("ledgerInternalNamespace")]
    public string? LedgerInternalNamespace { get; set; }

    [JsonPropertyName("ledgerName")]
    public string? LedgerName { get; set; }

    [JsonPropertyName("ledgerType")]
    public LedgerTypeConstant? LedgerType { get; set; }

    [JsonPropertyName("ledgerUri")]
    public string? LedgerUri { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
