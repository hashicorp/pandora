// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPresence;

internal class SetUserByIdPresencePresenceRequestModel
{
    [JsonPropertyName("activity")]
    public string? Activity { get; set; }

    [JsonPropertyName("availability")]
    public string? Availability { get; set; }

    [JsonPropertyName("expirationDuration")]
    public string? ExpirationDuration { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }
}
