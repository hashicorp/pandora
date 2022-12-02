using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupProtectionContainers;


internal class InquiryInfoModel
{
    [JsonPropertyName("errorDetail")]
    public ErrorDetailModel? ErrorDetail { get; set; }

    [JsonPropertyName("inquiryDetails")]
    public List<WorkloadInquiryDetailsModel>? InquiryDetails { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
