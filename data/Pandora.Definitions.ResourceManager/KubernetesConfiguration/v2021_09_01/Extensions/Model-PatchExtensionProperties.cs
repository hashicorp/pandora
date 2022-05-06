using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.Extensions;


internal class PatchExtensionPropertiesModel
{
    [JsonPropertyName("autoUpgradeMinorVersion")]
    public bool? AutoUpgradeMinorVersion { get; set; }

    [JsonPropertyName("configurationProtectedSettings")]
    public Dictionary<string, string>? ConfigurationProtectedSettings { get; set; }

    [JsonPropertyName("configurationSettings")]
    public Dictionary<string, string>? ConfigurationSettings { get; set; }

    [JsonPropertyName("releaseTrain")]
    public string? ReleaseTrain { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
