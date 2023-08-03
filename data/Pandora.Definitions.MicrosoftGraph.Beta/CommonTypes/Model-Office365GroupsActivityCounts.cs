// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Office365GroupsActivityCountsModel
{
    [JsonPropertyName("exchangeEmailsReceived")]
    public long? ExchangeEmailsReceived { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reportDate")]
    public DateTime? ReportDate { get; set; }

    [JsonPropertyName("reportPeriod")]
    public string? ReportPeriod { get; set; }

    [JsonPropertyName("reportRefreshDate")]
    public DateTime? ReportRefreshDate { get; set; }

    [JsonPropertyName("teamsChannelMessages")]
    public long? TeamsChannelMessages { get; set; }

    [JsonPropertyName("teamsMeetingsOrganized")]
    public long? TeamsMeetingsOrganized { get; set; }

    [JsonPropertyName("yammerMessagesLiked")]
    public long? YammerMessagesLiked { get; set; }

    [JsonPropertyName("yammerMessagesPosted")]
    public long? YammerMessagesPosted { get; set; }

    [JsonPropertyName("yammerMessagesRead")]
    public long? YammerMessagesRead { get; set; }
}
