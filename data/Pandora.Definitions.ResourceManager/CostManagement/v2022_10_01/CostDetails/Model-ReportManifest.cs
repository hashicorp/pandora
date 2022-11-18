using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.CostDetails;


internal class ReportManifestModel
{
    [JsonPropertyName("blobCount")]
    public int? BlobCount { get; set; }

    [JsonPropertyName("blobs")]
    public List<BlobInfoModel>? Blobs { get; set; }

    [JsonPropertyName("byteCount")]
    public int? ByteCount { get; set; }

    [JsonPropertyName("compressData")]
    public bool? CompressData { get; set; }

    [JsonPropertyName("dataFormat")]
    public CostDetailsDataFormatConstant? DataFormat { get; set; }

    [JsonPropertyName("manifestVersion")]
    public string? ManifestVersion { get; set; }

    [JsonPropertyName("requestContext")]
    public RequestContextModel? RequestContext { get; set; }
}
