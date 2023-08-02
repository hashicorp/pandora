// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityThreatSubmissionRootModel
{
    [JsonPropertyName("emailThreatSubmissionPolicies")]
    public List<EmailThreatSubmissionPolicyModel>? EmailThreatSubmissionPolicies { get; set; }

    [JsonPropertyName("emailThreats")]
    public List<EmailThreatSubmissionModel>? EmailThreats { get; set; }

    [JsonPropertyName("fileThreats")]
    public List<FileThreatSubmissionModel>? FileThreats { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("urlThreats")]
    public List<UrlThreatSubmissionModel>? UrlThreats { get; set; }
}
