using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Provider;


internal class GitHubActionWebAppStackSettingsModel
{
    [JsonPropertyName("isSupported")]
    public bool? IsSupported { get; set; }

    [JsonPropertyName("supportedVersion")]
    public string? SupportedVersion { get; set; }
}
