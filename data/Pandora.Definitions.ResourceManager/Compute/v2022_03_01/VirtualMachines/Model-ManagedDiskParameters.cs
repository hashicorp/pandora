using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;


internal class ManagedDiskParametersModel
{
    [JsonPropertyName("diskEncryptionSet")]
    public SubResourceModel? DiskEncryptionSet { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("securityProfile")]
    public VMDiskSecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("storageAccountType")]
    public StorageAccountTypesConstant? StorageAccountType { get; set; }
}
