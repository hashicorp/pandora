using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.SoftDeletedContainers;


internal class InquiryValidationModel
{
    [JsonPropertyName("additionalDetail")]
    public string? AdditionalDetail { get; set; }

    [JsonPropertyName("errorDetail")]
    public ErrorDetailModel? ErrorDetail { get; set; }

    [JsonPropertyName("protectableItemCount")]
    public object? ProtectableItemCount { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
