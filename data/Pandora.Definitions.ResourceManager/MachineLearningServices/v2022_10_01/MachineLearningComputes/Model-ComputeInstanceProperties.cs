using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.MachineLearningComputes;


internal class ComputeInstancePropertiesModel
{
    [JsonPropertyName("applicationSharingPolicy")]
    public ApplicationSharingPolicyConstant? ApplicationSharingPolicy { get; set; }

    [JsonPropertyName("applications")]
    public List<ComputeInstanceApplicationModel>? Applications { get; set; }

    [JsonPropertyName("computeInstanceAuthorizationType")]
    public ComputeInstanceAuthorizationTypeConstant? ComputeInstanceAuthorizationType { get; set; }

    [JsonPropertyName("connectivityEndpoints")]
    public ComputeInstanceConnectivityEndpointsModel? ConnectivityEndpoints { get; set; }

    [JsonPropertyName("containers")]
    public List<ComputeInstanceContainerModel>? Containers { get; set; }

    [JsonPropertyName("createdBy")]
    public ComputeInstanceCreatedByModel? CreatedBy { get; set; }

    [JsonPropertyName("dataDisks")]
    public List<ComputeInstanceDataDiskModel>? DataDisks { get; set; }

    [JsonPropertyName("dataMounts")]
    public List<ComputeInstanceDataMountModel>? DataMounts { get; set; }

    [JsonPropertyName("enableNodePublicIp")]
    public bool? EnableNodePublicIP { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorResponseModel>? Errors { get; set; }

    [JsonPropertyName("lastOperation")]
    public ComputeInstanceLastOperationModel? LastOperation { get; set; }

    [JsonPropertyName("personalComputeInstanceSettings")]
    public PersonalComputeInstanceSettingsModel? PersonalComputeInstanceSettings { get; set; }

    [JsonPropertyName("schedules")]
    public ComputeSchedulesModel? Schedules { get; set; }

    [JsonPropertyName("setupScripts")]
    public SetupScriptsModel? SetupScripts { get; set; }

    [JsonPropertyName("sshSettings")]
    public ComputeInstanceSshSettingsModel? SshSettings { get; set; }

    [JsonPropertyName("state")]
    public ComputeInstanceStateConstant? State { get; set; }

    [JsonPropertyName("subnet")]
    public ResourceIdModel? Subnet { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VMSize { get; set; }

    [JsonPropertyName("versions")]
    public ComputeInstanceVersionModel? Versions { get; set; }
}
