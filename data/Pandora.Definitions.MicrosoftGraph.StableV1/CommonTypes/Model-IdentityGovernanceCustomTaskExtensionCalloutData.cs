// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityGovernanceCustomTaskExtensionCalloutDataModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("subject")]
    public UserModel? Subject { get; set; }

    [JsonPropertyName("task")]
    public IdentityGovernanceTaskModel? Task { get; set; }

    [JsonPropertyName("taskProcessingresult")]
    public IdentityGovernanceTaskProcessingResultModel? TaskProcessingresult { get; set; }

    [JsonPropertyName("workflow")]
    public IdentityGovernanceWorkflowModel? Workflow { get; set; }
}
