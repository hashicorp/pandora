// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDeviceSoftwareVersionsModel
{
    [JsonPropertyName("adminAgentSoftwareVersion")]
    public string? AdminAgentSoftwareVersion { get; set; }

    [JsonPropertyName("firmwareSoftwareVersion")]
    public string? FirmwareSoftwareVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystemSoftwareVersion")]
    public string? OperatingSystemSoftwareVersion { get; set; }

    [JsonPropertyName("partnerAgentSoftwareVersion")]
    public string? PartnerAgentSoftwareVersion { get; set; }

    [JsonPropertyName("teamsClientSoftwareVersion")]
    public string? TeamsClientSoftwareVersion { get; set; }
}
