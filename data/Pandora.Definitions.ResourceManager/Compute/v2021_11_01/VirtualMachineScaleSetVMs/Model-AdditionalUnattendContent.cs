using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetVMs;


internal class AdditionalUnattendContentModel
{
    [JsonPropertyName("componentName")]
    public ComponentNamesConstant? ComponentName { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("passName")]
    public PassNamesConstant? PassName { get; set; }

    [JsonPropertyName("settingName")]
    public SettingNamesConstant? SettingName { get; set; }
}
