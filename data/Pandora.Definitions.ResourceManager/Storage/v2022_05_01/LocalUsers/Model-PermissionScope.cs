using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.LocalUsers;


internal class PermissionScopeModel
{
    [JsonPropertyName("permissions")]
    [Required]
    public string Permissions { get; set; }

    [JsonPropertyName("resourceName")]
    [Required]
    public string ResourceName { get; set; }

    [JsonPropertyName("service")]
    [Required]
    public string Service { get; set; }
}
