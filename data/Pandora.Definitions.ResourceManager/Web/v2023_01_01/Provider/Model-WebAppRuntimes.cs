using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Provider;


internal class WebAppRuntimesModel
{
    [JsonPropertyName("linuxContainerSettings")]
    public LinuxJavaContainerSettingsModel? LinuxContainerSettings { get; set; }

    [JsonPropertyName("linuxRuntimeSettings")]
    public WebAppRuntimeSettingsModel? LinuxRuntimeSettings { get; set; }

    [JsonPropertyName("windowsContainerSettings")]
    public WindowsJavaContainerSettingsModel? WindowsContainerSettings { get; set; }

    [JsonPropertyName("windowsRuntimeSettings")]
    public WebAppRuntimeSettingsModel? WindowsRuntimeSettings { get; set; }
}
