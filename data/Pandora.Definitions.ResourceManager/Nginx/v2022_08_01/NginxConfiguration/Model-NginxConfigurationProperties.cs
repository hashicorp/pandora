using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxConfiguration;


internal class NginxConfigurationPropertiesModel
{
    [JsonPropertyName("files")]
    public List<NginxConfigurationFileModel>? Files { get; set; }

    [JsonPropertyName("package")]
    public NginxConfigurationPackageModel? Package { get; set; }

    [JsonPropertyName("protectedFiles")]
    public List<NginxConfigurationFileModel>? ProtectedFiles { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rootFile")]
    public string? RootFile { get; set; }
}
