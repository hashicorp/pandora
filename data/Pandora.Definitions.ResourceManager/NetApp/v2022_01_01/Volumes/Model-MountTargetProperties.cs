using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_01_01.Volumes;


internal class MountTargetPropertiesModel
{
    [JsonPropertyName("fileSystemId")]
    [Required]
    public string FileSystemId { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("mountTargetId")]
    public string? MountTargetId { get; set; }

    [JsonPropertyName("smbServerFqdn")]
    public string? SmbServerFqdn { get; set; }
}
