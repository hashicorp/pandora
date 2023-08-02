// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class GroupLifecyclePolicyModel
{
    [JsonPropertyName("alternateNotificationEmails")]
    public string? AlternateNotificationEmails { get; set; }

    [JsonPropertyName("groupLifetimeInDays")]
    public int? GroupLifetimeInDays { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("managedGroupTypes")]
    public string? ManagedGroupTypes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
