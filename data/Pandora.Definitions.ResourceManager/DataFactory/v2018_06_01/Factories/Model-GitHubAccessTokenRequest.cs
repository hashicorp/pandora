using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Factories;


internal class GitHubAccessTokenRequestModel
{
    [JsonPropertyName("gitHubAccessCode")]
    [Required]
    public string GitHubAccessCode { get; set; }

    [JsonPropertyName("gitHubAccessTokenBaseUrl")]
    [Required]
    public string GitHubAccessTokenBaseUrl { get; set; }

    [JsonPropertyName("gitHubClientId")]
    public string? GitHubClientId { get; set; }

    [JsonPropertyName("gitHubClientSecret")]
    public GitHubClientSecretModel? GitHubClientSecret { get; set; }
}
