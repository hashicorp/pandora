using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Factories;

[ValueForType("FactoryGitHubConfiguration")]
internal class FactoryGitHubConfigurationModel : FactoryRepoConfigurationModel
{
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public GitHubClientSecretModel? ClientSecret { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }
}
