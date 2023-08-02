// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SessionModel
{
    [JsonPropertyName("callee")]
    public EndpointModel? Callee { get; set; }

    [JsonPropertyName("caller")]
    public EndpointModel? Caller { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("failureInfo")]
    public FailureInfoModel? FailureInfo { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isTest")]
    public bool? IsTest { get; set; }

    [JsonPropertyName("modalities")]
    public List<ModalityConstant>? Modalities { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("segments")]
    public List<SegmentModel>? Segments { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
