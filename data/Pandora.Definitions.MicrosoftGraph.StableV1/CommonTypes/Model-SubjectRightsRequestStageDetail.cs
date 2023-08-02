// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SubjectRightsRequestStageDetailModel
{
    [JsonPropertyName("error")]
    public PublicErrorModel? Error { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("stage")]
    public SubjectRightsRequestStageConstant? Stage { get; set; }

    [JsonPropertyName("status")]
    public SubjectRightsRequestStageStatusConstant? Status { get; set; }
}
