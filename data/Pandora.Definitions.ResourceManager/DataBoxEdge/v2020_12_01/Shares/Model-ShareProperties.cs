using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Shares;


internal class SharePropertiesModel
{
    [JsonPropertyName("accessProtocol")]
    [Required]
    public ShareAccessProtocolConstant AccessProtocol { get; set; }

    [JsonPropertyName("azureContainerInfo")]
    public AzureContainerInfoModel? AzureContainerInfo { get; set; }

    [JsonPropertyName("clientAccessRights")]
    public List<ClientAccessRightModel>? ClientAccessRights { get; set; }

    [JsonPropertyName("dataPolicy")]
    public DataPolicyConstant? DataPolicy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("monitoringStatus")]
    [Required]
    public MonitoringStatusConstant MonitoringStatus { get; set; }

    [JsonPropertyName("refreshDetails")]
    public RefreshDetailsModel? RefreshDetails { get; set; }

    [JsonPropertyName("shareMappings")]
    public List<MountPointMapModel>? ShareMappings { get; set; }

    [JsonPropertyName("shareStatus")]
    [Required]
    public ShareStatusConstant ShareStatus { get; set; }

    [JsonPropertyName("userAccessRights")]
    public List<UserAccessRightModel>? UserAccessRights { get; set; }
}
