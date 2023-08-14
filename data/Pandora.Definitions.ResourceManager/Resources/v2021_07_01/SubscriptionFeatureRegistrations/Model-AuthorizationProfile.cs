using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_07_01.SubscriptionFeatureRegistrations;


internal class AuthorizationProfileModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("approvedTime")]
    public DateTime? ApprovedTime { get; set; }

    [JsonPropertyName("approver")]
    public string? Approver { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("requestedTime")]
    public DateTime? RequestedTime { get; set; }

    [JsonPropertyName("requester")]
    public string? Requester { get; set; }

    [JsonPropertyName("requesterObjectId")]
    public string? RequesterObjectId { get; set; }
}
