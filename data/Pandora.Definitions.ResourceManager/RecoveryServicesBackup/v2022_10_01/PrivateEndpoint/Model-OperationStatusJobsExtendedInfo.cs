using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.PrivateEndpoint;

[ValueForType("OperationStatusJobsExtendedInfo")]
internal class OperationStatusJobsExtendedInfoModel : OperationStatusExtendedInfoModel
{
    [JsonPropertyName("failedJobsError")]
    public Dictionary<string, string>? FailedJobsError { get; set; }

    [JsonPropertyName("jobIds")]
    public List<string>? JobIds { get; set; }
}
