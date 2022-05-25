using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class SlackChannelPropertiesModel
{
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }

    [JsonPropertyName("isValidated")]
    public bool? IsValidated { get; set; }

    [JsonPropertyName("landingPageUrl")]
    public string? LandingPageUrl { get; set; }

    [JsonPropertyName("lastSubmissionId")]
    public string? LastSubmissionId { get; set; }

    [JsonPropertyName("redirectAction")]
    public string? RedirectAction { get; set; }

    [JsonPropertyName("registerBeforeOAuthFlow")]
    public bool? RegisterBeforeOAuthFlow { get; set; }

    [JsonPropertyName("signingSecret")]
    public string? SigningSecret { get; set; }

    [JsonPropertyName("verificationToken")]
    public string? VerificationToken { get; set; }
}
