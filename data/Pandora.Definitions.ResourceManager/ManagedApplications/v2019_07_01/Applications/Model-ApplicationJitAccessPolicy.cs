using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.Applications;


internal class ApplicationJitAccessPolicyModel
{
    [JsonPropertyName("jitAccessEnabled")]
    [Required]
    public bool JitAccessEnabled { get; set; }

    [JsonPropertyName("jitApprovalMode")]
    public JitApprovalModeConstant? JitApprovalMode { get; set; }

    [JsonPropertyName("jitApprovers")]
    public List<JitApproverDefinitionModel>? JitApprovers { get; set; }

    [JsonPropertyName("maximumJitAccessDuration")]
    public string? MaximumJitAccessDuration { get; set; }
}
