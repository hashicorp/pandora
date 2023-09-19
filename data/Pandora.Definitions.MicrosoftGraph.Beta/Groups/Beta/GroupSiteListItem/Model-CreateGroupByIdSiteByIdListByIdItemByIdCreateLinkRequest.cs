// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListItem;

internal class CreateGroupByIdSiteByIdListByIdItemByIdCreateLinkRequestModel
{
    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("recipients")]
    public List<DriveRecipientModel>? Recipients { get; set; }

    [JsonPropertyName("retainInheritedPermissions")]
    public bool? RetainInheritedPermissions { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("sendNotification")]
    public bool? SendNotification { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
