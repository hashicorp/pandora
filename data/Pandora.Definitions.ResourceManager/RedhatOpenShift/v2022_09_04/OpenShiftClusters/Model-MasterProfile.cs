using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedhatOpenShift.v2022_09_04.OpenShiftClusters;


internal class MasterProfileModel
{
    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("encryptionAtHost")]
    public EncryptionAtHostConstant? EncryptionAtHost { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VMSize { get; set; }
}
