// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListContentType;

internal class CreateGroupByIdSiteByIdListByIdContentTypeByIdAssociateWithHubSiteRequestModel
{
    [JsonPropertyName("hubSiteUrls")]
    public List<string>? HubSiteUrls { get; set; }

    [JsonPropertyName("propagateToExistingLists")]
    public bool? PropagateToExistingLists { get; set; }
}
