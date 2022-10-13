using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.LocalUsers;


internal class LocalUserPropertiesModel
{
    [JsonPropertyName("hasSharedKey")]
    public bool? HasSharedKey { get; set; }

    [JsonPropertyName("hasSshKey")]
    public bool? HasSshKey { get; set; }

    [JsonPropertyName("hasSshPassword")]
    public bool? HasSshPassword { get; set; }

    [JsonPropertyName("homeDirectory")]
    public string? HomeDirectory { get; set; }

    [JsonPropertyName("permissionScopes")]
    public List<PermissionScopeModel>? PermissionScopes { get; set; }

    [JsonPropertyName("sid")]
    public string? Sid { get; set; }

    [JsonPropertyName("sshAuthorizedKeys")]
    public List<SshPublicKeyModel>? SshAuthorizedKeys { get; set; }
}
