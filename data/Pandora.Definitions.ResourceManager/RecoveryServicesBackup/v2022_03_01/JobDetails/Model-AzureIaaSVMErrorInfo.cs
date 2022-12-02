using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.JobDetails;


internal class AzureIaaSVMErrorInfoModel
{
    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("errorString")]
    public string? ErrorString { get; set; }

    [JsonPropertyName("errorTitle")]
    public string? ErrorTitle { get; set; }

    [JsonPropertyName("recommendations")]
    public List<string>? Recommendations { get; set; }
}
