// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NotifyUserActionModel
{
    [JsonPropertyName("action")]
    public DlpActionConstant? Action { get; set; }

    [JsonPropertyName("actionLastModifiedDateTime")]
    public DateTime? ActionLastModifiedDateTime { get; set; }

    [JsonPropertyName("emailText")]
    public string? EmailText { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyTip")]
    public string? PolicyTip { get; set; }

    [JsonPropertyName("recipients")]
    public List<string>? Recipients { get; set; }
}
