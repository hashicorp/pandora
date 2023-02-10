using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;


internal class PrimingJobModel
{
    [JsonPropertyName("primingJobDetails")]
    public string? PrimingJobDetails { get; set; }

    [JsonPropertyName("primingJobId")]
    public string? PrimingJobId { get; set; }

    [JsonPropertyName("primingJobName")]
    [Required]
    public string PrimingJobName { get; set; }

    [JsonPropertyName("primingJobPercentComplete")]
    public float? PrimingJobPercentComplete { get; set; }

    [JsonPropertyName("primingJobState")]
    public PrimingJobStateConstant? PrimingJobState { get; set; }

    [JsonPropertyName("primingJobStatus")]
    public string? PrimingJobStatus { get; set; }

    [JsonPropertyName("primingManifestUrl")]
    [Required]
    public string PrimingManifestUrl { get; set; }
}
