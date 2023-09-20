// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkSoftwareUpdateHealthModel
{
    [JsonPropertyName("adminAgentSoftwareUpdateStatus")]
    public TeamworkSoftwareUpdateStatusModel? AdminAgentSoftwareUpdateStatus { get; set; }

    [JsonPropertyName("companyPortalSoftwareUpdateStatus")]
    public TeamworkSoftwareUpdateStatusModel? CompanyPortalSoftwareUpdateStatus { get; set; }

    [JsonPropertyName("firmwareSoftwareUpdateStatus")]
    public TeamworkSoftwareUpdateStatusModel? FirmwareSoftwareUpdateStatus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystemSoftwareUpdateStatus")]
    public TeamworkSoftwareUpdateStatusModel? OperatingSystemSoftwareUpdateStatus { get; set; }

    [JsonPropertyName("partnerAgentSoftwareUpdateStatus")]
    public TeamworkSoftwareUpdateStatusModel? PartnerAgentSoftwareUpdateStatus { get; set; }

    [JsonPropertyName("teamsClientSoftwareUpdateStatus")]
    public TeamworkSoftwareUpdateStatusModel? TeamsClientSoftwareUpdateStatus { get; set; }
}
