using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Devices;


internal class DeviceSecretsModel
{
    [JsonPropertyName("bmcDefaultUserPassword")]
    public SecretModel? BmcDefaultUserPassword { get; set; }

    [JsonPropertyName("hcsDataVolumeBitLockerExternalKey")]
    public SecretModel? HcsDataVolumeBitLockerExternalKey { get; set; }

    [JsonPropertyName("hcsInternalVolumeBitLockerExternalKey")]
    public SecretModel? HcsInternalVolumeBitLockerExternalKey { get; set; }

    [JsonPropertyName("rotateKeyForDataVolumeBitlocker")]
    public SecretModel? RotateKeyForDataVolumeBitlocker { get; set; }

    [JsonPropertyName("rotateKeysForSedDrivesSerialized")]
    public SecretModel? RotateKeysForSedDrivesSerialized { get; set; }

    [JsonPropertyName("sedEncryptionExternalKey")]
    public SecretModel? SedEncryptionExternalKey { get; set; }

    [JsonPropertyName("sedEncryptionExternalKeyId")]
    public SecretModel? SedEncryptionExternalKeyId { get; set; }

    [JsonPropertyName("systemVolumeBitLockerRecoveryKey")]
    public SecretModel? SystemVolumeBitLockerRecoveryKey { get; set; }
}
