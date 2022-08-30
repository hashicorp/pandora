using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;


internal class WindowsPropertiesModel
{
    [JsonPropertyName("excludedKbNumbers")]
    public List<string>? ExcludedKbNumbers { get; set; }

    [JsonPropertyName("includedKbNumbers")]
    public List<string>? IncludedKbNumbers { get; set; }

    [JsonPropertyName("includedUpdateClassifications")]
    public WindowsUpdateClassesConstant? IncludedUpdateClassifications { get; set; }

    [JsonPropertyName("rebootSetting")]
    public string? RebootSetting { get; set; }
}
