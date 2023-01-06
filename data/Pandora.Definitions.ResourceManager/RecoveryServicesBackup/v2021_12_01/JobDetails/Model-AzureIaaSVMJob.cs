using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.JobDetails;

[ValueForType("AzureIaaSVMJob")]
internal class AzureIaaSVMJobModel : JobModel
{
    [JsonPropertyName("actionsInfo")]
    public List<JobSupportedActionConstant>? ActionsInfo { get; set; }

    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<AzureIaaSVMErrorInfoModel>? ErrorDetails { get; set; }

    [JsonPropertyName("extendedInfo")]
    public AzureIaaSVMJobExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("isUserTriggered")]
    public bool? IsUserTriggered { get; set; }

    [JsonPropertyName("virtualMachineVersion")]
    public string? VirtualMachineVersion { get; set; }
}
