// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentRequestCallbackDataModel
{
    [JsonPropertyName("customExtensionStageInstanceDetail")]
    public string? CustomExtensionStageInstanceDetail { get; set; }

    [JsonPropertyName("customExtensionStageInstanceId")]
    public string? CustomExtensionStageInstanceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("stage")]
    public AccessPackageAssignmentRequestCallbackDataStageConstant? Stage { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
