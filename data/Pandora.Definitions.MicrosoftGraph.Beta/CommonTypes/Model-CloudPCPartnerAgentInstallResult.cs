// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCPartnerAgentInstallResultModel
{
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("installStatus")]
    public CloudPCPartnerAgentInstallResultInstallStatusConstant? InstallStatus { get; set; }

    [JsonPropertyName("isThirdPartyPartner")]
    public bool? IsThirdPartyPartner { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("partnerAgentName")]
    public CloudPCPartnerAgentInstallResultPartnerAgentNameConstant? PartnerAgentName { get; set; }

    [JsonPropertyName("retriable")]
    public bool? Retriable { get; set; }
}
