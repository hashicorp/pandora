// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DomainDnsCnameRecordModel
{
    [JsonPropertyName("canonicalName")]
    public string? CanonicalName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isOptional")]
    public bool? IsOptional { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recordType")]
    public string? RecordType { get; set; }

    [JsonPropertyName("supportedService")]
    public string? SupportedService { get; set; }

    [JsonPropertyName("ttl")]
    public int? Ttl { get; set; }
}
