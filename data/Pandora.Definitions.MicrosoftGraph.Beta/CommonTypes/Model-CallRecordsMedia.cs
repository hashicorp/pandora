// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsMediaModel
{
    [JsonPropertyName("calleeDevice")]
    public CallRecordsDeviceInfoModel? CalleeDevice { get; set; }

    [JsonPropertyName("calleeNetwork")]
    public CallRecordsNetworkInfoModel? CalleeNetwork { get; set; }

    [JsonPropertyName("callerDevice")]
    public CallRecordsDeviceInfoModel? CallerDevice { get; set; }

    [JsonPropertyName("callerNetwork")]
    public CallRecordsNetworkInfoModel? CallerNetwork { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("streams")]
    public List<CallRecordsMediaStreamModel>? Streams { get; set; }
}
