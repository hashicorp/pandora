using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Roles;


internal class MountPointMapModel
{
    [JsonPropertyName("mountPoint")]
    public string? MountPoint { get; set; }

    [JsonPropertyName("mountType")]
    public MountTypeConstant? MountType { get; set; }

    [JsonPropertyName("roleId")]
    public string? RoleId { get; set; }

    [JsonPropertyName("roleType")]
    public RoleTypesConstant? RoleType { get; set; }

    [JsonPropertyName("shareId")]
    [Required]
    public string ShareId { get; set; }
}
