using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;


internal class LinuxPropertiesModel
{
    [JsonPropertyName("excludedPackageNameMasks")]
    public List<string>? ExcludedPackageNameMasks { get; set; }

    [JsonPropertyName("includedPackageClassifications")]
    public LinuxUpdateClassesConstant? IncludedPackageClassifications { get; set; }

    [JsonPropertyName("includedPackageNameMasks")]
    public List<string>? IncludedPackageNameMasks { get; set; }

    [JsonPropertyName("rebootSetting")]
    public string? RebootSetting { get; set; }
}
