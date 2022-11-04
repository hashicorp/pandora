using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.User;


internal class UserPropertiesModel
{
    [JsonPropertyName("additionalUsageQuota")]
    public string? AdditionalUsageQuota { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    [Required]
    public string Email { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("invitationSent")]
    public DateTime? InvitationSent { get; set; }

    [JsonPropertyName("invitationState")]
    public InvitationStateConstant? InvitationState { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("registrationState")]
    public RegistrationStateConstant? RegistrationState { get; set; }

    [JsonPropertyName("totalUsage")]
    public string? TotalUsage { get; set; }
}
