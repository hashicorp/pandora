using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagers;


internal class NetworkManagerCommitModel
{
    [JsonPropertyName("commitId")]
    public string? CommitId { get; set; }

    [JsonPropertyName("commitType")]
    [Required]
    public ConfigurationTypeConstant CommitType { get; set; }

    [JsonPropertyName("configurationIds")]
    public List<string>? ConfigurationIds { get; set; }

    [JsonPropertyName("targetLocations")]
    [Required]
    public List<string> TargetLocations { get; set; }
}
