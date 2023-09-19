// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarView;

internal class CreateMeCalendarViewByIdForwardRequestModel
{
    [JsonPropertyName("Comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("ToRecipients")]
    public List<RecipientModel>? ToRecipients { get; set; }
}
