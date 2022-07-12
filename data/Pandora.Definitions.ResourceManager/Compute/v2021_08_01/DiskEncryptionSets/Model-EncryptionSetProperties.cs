using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.DiskEncryptionSets;


internal class EncryptionSetPropertiesModel
{
    [JsonPropertyName("activeKey")]
    public KeyForDiskEncryptionSetModel? ActiveKey { get; set; }

    [JsonPropertyName("autoKeyRotationError")]
    public ApiErrorModel? AutoKeyRotationError { get; set; }

    [JsonPropertyName("encryptionType")]
    public DiskEncryptionSetTypeConstant? EncryptionType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastKeyRotationTimestamp")]
    public DateTime? LastKeyRotationTimestamp { get; set; }

    [JsonPropertyName("previousKeys")]
    public List<KeyForDiskEncryptionSetModel>? PreviousKeys { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("rotationToLatestKeyVersionEnabled")]
    public bool? RotationToLatestKeyVersionEnabled { get; set; }
}
