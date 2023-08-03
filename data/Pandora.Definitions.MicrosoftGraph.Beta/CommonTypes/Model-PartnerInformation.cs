// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PartnerInformationModel
{
    [JsonPropertyName("commerceUrl")]
    public string? CommerceUrl { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("companyType")]
    public PartnerTenantTypeConstant? CompanyType { get; set; }

    [JsonPropertyName("helpUrl")]
    public string? HelpUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("partnerTenantId")]
    public string? PartnerTenantId { get; set; }

    [JsonPropertyName("supportEmails")]
    public List<string>? SupportEmails { get; set; }

    [JsonPropertyName("supportTelephones")]
    public List<string>? SupportTelephones { get; set; }

    [JsonPropertyName("supportUrl")]
    public string? SupportUrl { get; set; }
}
