using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.CodeVersion;


internal class BlobReferenceForConsumptionDtoModel
{
    [JsonPropertyName("blobUri")]
    public string? BlobUri { get; set; }

    [JsonPropertyName("credential")]
    public PendingUploadCredentialDtoModel? Credential { get; set; }

    [JsonPropertyName("storageAccountArmId")]
    public string? StorageAccountArmId { get; set; }
}
