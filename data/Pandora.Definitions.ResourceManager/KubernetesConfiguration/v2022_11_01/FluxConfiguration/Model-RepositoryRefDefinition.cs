using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.FluxConfiguration;


internal class RepositoryRefDefinitionModel
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("commit")]
    public string? Commit { get; set; }

    [JsonPropertyName("semver")]
    public string? Semver { get; set; }

    [JsonPropertyName("tag")]
    public string? Tag { get; set; }
}
