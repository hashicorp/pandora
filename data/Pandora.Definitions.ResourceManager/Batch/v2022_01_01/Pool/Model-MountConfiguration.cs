using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class MountConfigurationModel
{
    [JsonPropertyName("azureBlobFileSystemConfiguration")]
    public AzureBlobFileSystemConfigurationModel? AzureBlobFileSystemConfiguration { get; set; }

    [JsonPropertyName("azureFileShareConfiguration")]
    public AzureFileShareConfigurationModel? AzureFileShareConfiguration { get; set; }

    [JsonPropertyName("cifsMountConfiguration")]
    public CIFSMountConfigurationModel? CifsMountConfiguration { get; set; }

    [JsonPropertyName("nfsMountConfiguration")]
    public NFSMountConfigurationModel? NfsMountConfiguration { get; set; }
}
