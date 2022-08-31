using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2022_05_13.ConfidentialLedger;


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
