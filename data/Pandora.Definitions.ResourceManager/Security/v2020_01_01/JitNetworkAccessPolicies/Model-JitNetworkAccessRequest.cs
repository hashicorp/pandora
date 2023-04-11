using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;


internal class JitNetworkAccessRequestModel
{
    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

    [JsonPropertyName("requestor")]
    [Required]
    public string Requestor { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTimeUtc")]
    [Required]
    public DateTime StartTimeUtc { get; set; }

    [JsonPropertyName("virtualMachines")]
    [Required]
    public List<JitNetworkAccessRequestVirtualMachineModel> VirtualMachines { get; set; }
}
