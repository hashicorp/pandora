using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachineGroups;


internal class SqlVirtualMachineGroupPropertiesModel
{
    [JsonPropertyName("clusterConfiguration")]
    public ClusterConfigurationConstant? ClusterConfiguration { get; set; }

    [JsonPropertyName("clusterManagerType")]
    public ClusterManagerTypeConstant? ClusterManagerType { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("scaleType")]
    public ScaleTypeConstant? ScaleType { get; set; }

    [JsonPropertyName("sqlImageOffer")]
    public string? SqlImageOffer { get; set; }

    [JsonPropertyName("sqlImageSku")]
    public SqlVMGroupImageSkuConstant? SqlImageSku { get; set; }

    [JsonPropertyName("wsfcDomainProfile")]
    public WsfcDomainProfileModel? WsfcDomainProfile { get; set; }
}
