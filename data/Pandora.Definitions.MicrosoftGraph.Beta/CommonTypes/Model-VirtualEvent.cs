// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualEventModel
{
    [JsonPropertyName("createdBy")]
    public CommunicationsIdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("description")]
    public ItemBodyModel? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTimeTimeZoneModel? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("presenters")]
    public List<VirtualEventPresenterModel>? Presenters { get; set; }

    [JsonPropertyName("sessions")]
    public List<VirtualEventSessionModel>? Sessions { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTimeTimeZoneModel? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public VirtualEventStatusConstant? Status { get; set; }
}
