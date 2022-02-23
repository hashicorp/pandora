using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class BlobRestoreStatusModel
{
    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    [JsonPropertyName("parameters")]
    public BlobRestoreParametersModel? Parameters { get; set; }

    [JsonPropertyName("restoreId")]
    public string? RestoreId { get; set; }

    [JsonPropertyName("status")]
    public BlobRestoreProgressStatusConstant? Status { get; set; }
}
