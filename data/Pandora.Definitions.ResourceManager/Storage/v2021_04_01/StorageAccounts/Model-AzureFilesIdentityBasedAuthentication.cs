using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class AzureFilesIdentityBasedAuthenticationModel
{
    [JsonPropertyName("activeDirectoryProperties")]
    public ActiveDirectoryPropertiesModel? ActiveDirectoryProperties { get; set; }

    [JsonPropertyName("defaultSharePermission")]
    public DefaultSharePermissionConstant? DefaultSharePermission { get; set; }

    [JsonPropertyName("directoryServiceOptions")]
    [Required]
    public DirectoryServiceOptionsConstant DirectoryServiceOptions { get; set; }
}
