using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsAuthConfigs;


internal class GlobalValidationModel
{
    [JsonPropertyName("excludedPaths")]
    public List<string>? ExcludedPaths { get; set; }

    [JsonPropertyName("redirectToProvider")]
    public string? RedirectToProvider { get; set; }

    [JsonPropertyName("unauthenticatedClientAction")]
    public UnauthenticatedClientActionV2Constant? UnauthenticatedClientAction { get; set; }
}
