using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.Invitation;


internal class InvitationPropertiesModel
{
    [JsonPropertyName("invitationId")]
    public string? InvitationId { get; set; }

    [JsonPropertyName("invitationStatus")]
    public InvitationStatusConstant? InvitationStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("respondedAt")]
    public DateTime? RespondedAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sentAt")]
    public DateTime? SentAt { get; set; }

    [JsonPropertyName("targetActiveDirectoryId")]
    public string? TargetActiveDirectoryId { get; set; }

    [JsonPropertyName("targetEmail")]
    public string? TargetEmail { get; set; }

    [JsonPropertyName("targetObjectId")]
    public string? TargetObjectId { get; set; }

    [JsonPropertyName("userEmail")]
    public string? UserEmail { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
