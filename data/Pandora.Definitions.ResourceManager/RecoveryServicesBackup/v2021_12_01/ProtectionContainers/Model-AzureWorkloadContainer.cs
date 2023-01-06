using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectionContainers;

[ValueForType("AzureWorkloadContainer")]
internal class AzureWorkloadContainerModel : ProtectionContainerModel
{
    [JsonPropertyName("extendedInfo")]
    public AzureWorkloadContainerExtendedInfoModel? ExtendedInfo { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTime")]
    public DateTime? LastUpdatedTime { get; set; }

    [JsonPropertyName("operationType")]
    public OperationTypeConstant? OperationType { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("workloadType")]
    public WorkloadTypeConstant? WorkloadType { get; set; }
}
