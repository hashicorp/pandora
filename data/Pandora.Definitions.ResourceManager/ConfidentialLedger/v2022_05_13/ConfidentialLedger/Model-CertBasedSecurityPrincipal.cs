using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConfidentialLedger.v2022_05_13.ConfidentialLedger;


internal class CertBasedSecurityPrincipalModel
{
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    [JsonPropertyName("ledgerRoleName")]
    public LedgerRoleNameConstant? LedgerRoleName { get; set; }
}
