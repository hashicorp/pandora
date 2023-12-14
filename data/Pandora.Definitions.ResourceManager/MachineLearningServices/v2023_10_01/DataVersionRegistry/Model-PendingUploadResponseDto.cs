using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataVersionRegistry;


internal class PendingUploadResponseDtoModel
{
    [JsonPropertyName("blobReferenceForConsumption")]
    public BlobReferenceForConsumptionDtoModel? BlobReferenceForConsumption { get; set; }

    [JsonPropertyName("pendingUploadId")]
    public string? PendingUploadId { get; set; }

    [JsonPropertyName("pendingUploadType")]
    public PendingUploadTypeConstant? PendingUploadType { get; set; }
}
